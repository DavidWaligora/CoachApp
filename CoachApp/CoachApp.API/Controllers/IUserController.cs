using CoachApp.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.API.Controllers;

public interface IUserController
{
    Task<IActionResult> LoginAsync(UserLoginDTO loginModel);
    Task<IActionResult> RegisterAsync(UserRegisterDTO registerModel);
    Task<IActionResult> GetUserInfoAsync();
    Task<IActionResult> UpdateUserInfoAsync(UpdateUserInfoDTO userInfoToUpdate);
    Task<IActionResult> UpdatePasswordAsync(UpdatePasswordDTO model);
    Task<IActionResult> DeleteUserInfoAsync();
}
