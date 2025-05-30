using CoachApp.DAL.Data.Models;
using CoachApp.DTO;

namespace CoachApp.Services.MiddleWare;

public static class UserServices
{
    public static bool CheckPasswordsAreTheSame(string pw1, string pw2)
    {
        return pw1 == pw2;
    }
    public static User GetUserFromRegisterUserDTO(UserRegisterDTO registerModel)
    {
        return new()
        {
            FirstName = registerModel.FirstName,
            LastName = registerModel.LastName,
            UserName = registerModel.UserName,
            Email = registerModel.Email,
            PhoneNumber = registerModel.PhoneNumber,
        };
    }
}
