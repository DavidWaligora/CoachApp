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
public class UserController : ControllerBase
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private readonly ITokenServices _tokenServices;
    private GetUserDataServices _userDataServices;

    public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenServices tokenServices, GetUserDataServices userDataServices)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenServices = tokenServices;
        _userDataServices = userDataServices;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginDTO loginModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(loginModel.UserNameOrEmail);
        if (user == null)
            user = await _userManager.FindByNameAsync(loginModel.UserNameOrEmail);
        if (user == null)
            return BadRequest("Given data is invalid!");

        if (await _userManager.CheckPasswordAsync(user, loginModel.Password) == false)
        {
            // Never give exact information: only say that the combination is incorrect...
            ModelState.AddModelError("message", "wrong loginCombination!");
            return BadRequest(loginModel);
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName!, loginModel.Password, false, true);

        if (result.IsLockedOut)
            ModelState.AddModelError("message", "Account locked!");

        if (result.Succeeded)
        {
            var token = _tokenServices.GetToken(user);

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

        var user = await _userManager.FindByEmailAsync(registerModel.Email);
        if (user != null)
        {
            ModelState.AddModelError("message", "User exists with this credentials!");
            return BadRequest(ModelState);
        }
        user = await _userManager.FindByNameAsync(registerModel.UserName);
        if (user != null)
        {
            ModelState.AddModelError("message", "User exists with this credentials!");
            return BadRequest(ModelState);
        }
        user = _userManager.Users.Where(x => x.PhoneNumber == registerModel.PhoneNumber).FirstOrDefault();
        if (user != null)
        {
            ModelState.AddModelError("message", "User exists with this credentials!");
            return BadRequest(ModelState);
        }


        User userToCreate = UserServices.GetUserFromRegisterUserDTO(registerModel);

        var result = await _userManager.CreateAsync(userToCreate, registerModel.Password1);

        if (result.Succeeded)
        {
            user = await _userManager.FindByEmailAsync(registerModel.Email);
            if (user == null)
            {
            return BadRequest();
            }
            var token = _tokenServices.GetToken(user!);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        if (result.Errors.Count() > 0)
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
        UserInfoDTO? user = await _userDataServices.GetUserInfoByIDAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }



}
