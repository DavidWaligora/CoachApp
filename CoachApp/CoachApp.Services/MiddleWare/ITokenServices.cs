using CoachApp.DAL.Data.Models;
using System.IdentityModel.Tokens.Jwt;

namespace CoachApp.Services.MiddleWare;
public interface ITokenServices
{
    JwtSecurityToken GetToken(DAL.Data.Models.User user);
}
