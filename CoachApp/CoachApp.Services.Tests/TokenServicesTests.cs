using CoachApp.DAL.Data.Models;
using CoachApp.Services.MiddleWare;
using CoachApp.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoachApp.Services.Tests;

public class TokenServicesTests
{
    private static JWTOptions GetJwtOptions()
    {
        return new JWTOptions
        {
            Key = "SuperSecretKey1234567890SuperSecretKey",
            Issuer = "MyTestIssuer",
            Audience = "MyTestAudience",
            DurationInMinutes = 30
        };
    }

    [Fact]
    public void GetToken_ShouldGenerateTokenWithExpectedClaims()
    {
        // Arrange
        var jwtOptions = GetJwtOptions();

        var user = new User
        {
            Id = 1,
            UserName = "john.doe",
            FirstName = "john",
            LastName = "doe",
            Email = "john.doe@test.com"
        };

        var service = new TokenServices(jwtOptions);

        // Act
        var token = service.GetToken(user);

        // Assert
        Assert.Equal("MyTestIssuer", token.Issuer);
        Assert.Contains("MyTestAudience", token.Audiences);
        Assert.Contains(token.Claims, c => c.Type == ClaimTypes.Name && c.Value == "john.doe");
        Assert.Contains(token.Claims, c => c.Type == ClaimTypes.NameIdentifier && c.Value == "1");
    }

    [Fact]
    public void GetToken_ShouldFail_WhenExpectedWrongUsername()
    {
        // Arrange
        var jwtOptions = GetJwtOptions();

        var user = new User
        {
            Id = 1,
            UserName = "john.doe",
            FirstName = "john",
            LastName = "doe",
            Email = "john.doe@test.com"
        };

        var service = new TokenServices(jwtOptions);

        // Act
        var token = service.GetToken(user);

        // Assert
        Assert.DoesNotContain(token.Claims, c => c.Type == ClaimTypes.Name && c.Value == "jane.doe");
    }

    [Fact]
    public void GetToken_ShouldBeValidAgainstTokenHandler()
    {
        // Arrange
        var jwtOptions = GetJwtOptions();

        var user = new User
        {
            Id = 1,
            UserName = "john.doe",
            FirstName = "john",
            LastName = "doe",
            Email = "john.doe@test.com"
        };

        var service = new TokenServices(jwtOptions);
        var token = service.GetToken(user);

        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            ClockSkew = TimeSpan.Zero
        };

        // Act
        var principal = tokenHandler.ValidateToken(new JwtSecurityTokenHandler().WriteToken(token), validationParameters, out _);

        // Assert
        Assert.Equal("john.doe", principal.Identity?.Name);
    }
}