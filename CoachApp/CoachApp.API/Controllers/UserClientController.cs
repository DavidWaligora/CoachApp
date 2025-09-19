using CoachApp.DAL.Data.Models;
using CoachApp.DAL.Data.UnitOfWork;
using CoachApp.Services.UserClientData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoachApp.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserClientController(UserClientDataServices userClientDataServices) : ControllerBase, IUserClientController
{
    [Authorize]
    [HttpGet("GetAllUserNamesWhereIsClient")]
    public async Task<ActionResult<string>> GetAllUserNamesWhereIsClient()
    {
        // Try to get the user ID from claims
        var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        // get all usernames
        try
        {
            List<string?> userNames = await userClientDataServices.GetCoachesWhereIsClientAsync(userId);
            if (userNames == null || userNames.Count == 0)
            {
                return NotFound("No coaches found for this user.");
            }
            return Ok(userNames);
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Problem receiving data, please try again.");
        }

    }

    [Authorize]
    [HttpGet("GetAllUserNamesWhereIsCoach")]
    public async Task<ActionResult<string>> GetAllUserNamesWhereIsCoach()
    {
        // Try to get the user ID from claims
        var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        // get all usernames
        try
        {
            List<string?> userNames = await userClientDataServices.GetClientsWhereIsCoachAsync(userId);
            if (userNames == null || userNames.Count == 0)
            {
                return NotFound("No clients found for this user.");
            }
            return Ok(userNames);
        }
        catch (Exception ex)
        {
            throw new BadHttpRequestException("Problem receiving data, please try again.");
        }
    }
}
