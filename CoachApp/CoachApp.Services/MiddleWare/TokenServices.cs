using CoachApp.DAL.Data.Models;
using CoachApp.Services.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoachApp.Services.MiddleWare;

public class TokenServices(IJWTOptions jWTOptions) : ITokenServices
{
    public JwtSecurityToken GetToken(User user)
    {
        var authClaims = GetClaims(user);
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTOptions.Key));
        var token = GetJwtSecurityToken(authClaims, authSigningKey);

        return token;
    }

    private static List<Claim> GetClaims(User user)
    {
        return
        [
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ];
    }

    private JwtSecurityToken GetJwtSecurityToken(List<Claim> authClaims, SymmetricSecurityKey authSigningKey)
    {
        return new JwtSecurityToken(
            issuer: jWTOptions.Issuer,
            audience: jWTOptions.Audience,
            expires: DateTime.UtcNow.AddMinutes(jWTOptions.DurationInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        
    }
}
