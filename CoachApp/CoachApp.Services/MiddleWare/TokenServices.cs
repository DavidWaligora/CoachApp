using CoachApp.DAL.Data.Models;
using CoachApp.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoachApp.Services.MiddleWare;

public class TokenServices : ITokenServices
{
    private readonly IJWTOptions _jwt;
    public TokenServices(IJWTOptions jWTOptions)
    {
        _jwt = jWTOptions;
    }
    public JwtSecurityToken GetToken(User user)
    {
        var authClaims = GetClaims(user);
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var token = GetJwtSecurityToken(authClaims, authSigningKey);

        return token;
    }

    private List<Claim> GetClaims(User user)
    {
        return new()
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
    }

    private JwtSecurityToken GetJwtSecurityToken(List<Claim> authClaims, SymmetricSecurityKey authSigningKey)
    {
        return new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        
    }
}
