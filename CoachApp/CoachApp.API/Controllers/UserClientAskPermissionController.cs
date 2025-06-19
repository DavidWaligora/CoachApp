using CoachApp.DAL.Data.Models;
using CoachApp.DAL.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoachApp.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserClientAskPermissionController(UserManager<User> userManager, IUnitOfWork uow) : ControllerBase, IUserClientAskPermissionController
{
    [HttpPut(Name = "AcceptAskPermission")]
    [Authorize]
    public async Task<IActionResult> AcceptOrDeclineAskPermissionAsync(string userName, bool choice)
    {
        var permissions = await uow.UserClientAskPermissionRepository.GetAllAsync();
        if (permissions == null || !permissions.Any())
        {
            return NotFound("No permissions found.");
        }
        var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        User? user = await userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        var permission = permissions.FirstOrDefault(x => x.UserID == user.Id && x.ClientID == userId && x.HasChosen == null);

        if (permission == null)
        {
            return NotFound("Permission not found or already accepted.");
        }

        permission.HasChosen = choice;

        try
        {
            uow.UserClientAskPermissionRepository.Update(permission);
            await uow.SaveChangesAsync();
            return Ok("Permission changed successfully.");
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)
            return BadRequest("Problem accepting permission! Please try again.");
            //TODO LOGGING
        }

    }

    [HttpPost(Name = "AddAsClient")]
    [Authorize]
    public async Task<IActionResult> AskPermissionAsync(string userName, int? userRoleID)
    {
        //var role = await uow.UserRoleRepository.GetByIdAsync(userRoleID); // Use .Value to access the int value
        //if (role == null)
        //{
        //    return BadRequest("Could not find the role");
        //}

        var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        User? userToAskPermission = await userManager.FindByNameAsync(userName);

        if (userToAskPermission == null)
        {
            return BadRequest("This user does not exist.");
        }


        var userAskPermissions = await uow.UserClientAskPermissionRepository.GetAllAsync();

        if (userAskPermissions != null)
        {
            if (userAskPermissions.Where(x => x.UserID == userId && x.ClientID == userToAskPermission.Id).Any())
                return BadRequest("You already asked this person to be you're client.");
        }


        try
        {
            await uow.UserClientAskPermissionRepository.AddAsync(
                new()
                {
                    UserID = userId,
                    ClientID = userToAskPermission.Id,
                    UserRoleID = userRoleID
                });

            await uow.SaveChangesAsync();
            return Ok("The client will receive a request to be you're client.");
        }
        catch (Exception ex)
        {
            return BadRequest("Problem sending request! Please try again.");
            // todo logger
        }
    }

    [Authorize]
    [HttpGet(Name = "GetAllAskClients")]
    public async Task<ActionResult<List<string>>?> GetAllAskClientsAsync()
    {
        var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        var userAskPermissions = await uow.UserClientAskPermissionRepository.GetAllAsync();

        List<int?> users = [.. userAskPermissions
            .Where(x=>x.ClientID == userId && x.HasChosen == null)
            .Select(x=>x.UserID)];

        if (users.Count == 0)
        {
            return null;
        }

        List<string?> userNames = await userManager.Users
            .Where(x => users.Contains(x.Id))
            .Select(x => x.UserName)
            .ToListAsync();

        if (userNames.Count == 0)
        {
            return null;
        }

        return userNames!;
    }


}
