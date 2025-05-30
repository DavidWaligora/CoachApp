using CoachApp.DAL.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoachApp.Services.MiddleWare;

public static class TokenService
{
    public static JwtSecurityToken GetToken(User user, IConfiguration config)
    {
        var authClaims = GetClaims(user);
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var token = GetJwtSecurityToken(authClaims, config, authSigningKey);

        return token;
    }

    private static List<Claim> GetClaims(User user)
    {
        return new()
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
    }

    private static JwtSecurityToken GetJwtSecurityToken(List<Claim> authClaims, IConfiguration config, SymmetricSecurityKey authSigningKey)
    {
        return new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            expires: DateTime.UtcNow.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        
    }
}
