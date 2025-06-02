using CoachApp.DAL.Data.Models;
using CoachApp.DTO.User;
using CoachApp.Services.MiddleWare;
using CoachApp.Services.UserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoachApp.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenServices tokenServices, GetUserDataServices userDataServices) : ControllerBase
{
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginDTO loginModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await userManager.FindByEmailAsync(loginModel.UserNameOrEmail);
        user ??= await userManager.FindByNameAsync(loginModel.UserNameOrEmail);
        if (user == null)
            return BadRequest("Given data is invalid!");

        if (await userManager.CheckPasswordAsync(user, loginModel.Password) == false)
        {
            // Never give exact information: only say that the combination is incorrect...
            ModelState.AddModelError("message", "wrong loginCombination!");
            return BadRequest(loginModel);
        }

        var result = await signInManager.PasswordSignInAsync(user.UserName!, loginModel.Password, false, true);

        if (result.IsLockedOut)
            ModelState.AddModelError("message", "Account locked!");

        if (result.Succeeded)
        {
            var token = tokenServices.GetToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        ModelState.AddModelError("message", "Invalid login try!");
        return Unauthorized(ModelState);
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(UserRegisterDTO registerModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!UserServices.CheckPasswordsAreTheSame(registerModel.Password1, registerModel.Password2))
            return BadRequest("The passwords dont match!");

        var user = await userManager.FindByEmailAsync(registerModel.Email);
        if (user != null)
        {
            ModelState.AddModelError("message", "User exists with this credentials!");
            return BadRequest(ModelState);
        }
        user = await userManager.FindByNameAsync(registerModel.UserName);
        if (user != null)
        {
            ModelState.AddModelError("message", "User exists with this credentials!");
            return BadRequest(ModelState);
        }
        user = userManager.Users.Where(x => x.PhoneNumber == registerModel.PhoneNumber).FirstOrDefault();
        if (user != null)
        {
            ModelState.AddModelError("message", "User exists with this credentials!");
            return BadRequest(ModelState);
        }


        User userToCreate = UserServices.GetUserFromRegisterUserDTO(registerModel);

        var result = await userManager.CreateAsync(userToCreate, registerModel.Password1);

        if (result.Succeeded)
        {
            user = await userManager.FindByEmailAsync(registerModel.Email);
            if (user == null)
            {
            return BadRequest();
            }
            var token = tokenServices.GetToken(user!);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        if (result.Errors.Any())
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("message", error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpGet(Name = "GetUserInfo")]
    [Authorize]
    public async Task<IActionResult> GetUserInfo()
    {
        // Try to get the user ID from claims
        var identity = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(identity) || !int.TryParse(identity, out int userId))
        {
            return BadRequest("Problem receiving data, please try again.");
        }

        // Call the service to get user info
        UserInfoDTO? user = await userDataServices.GetUserInfoByIDAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }



}
