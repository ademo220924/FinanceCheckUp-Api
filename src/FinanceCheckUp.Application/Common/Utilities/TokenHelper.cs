using FinanceCheckUp.Application.Models.SignOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FinanceCheckUp.Application.Common.Utilities;

public static class TokenHelper
{
    public static string? GetBearerToUser(HttpContext httpContext)
    {
        return httpContext?.Request?.Headers?.Authorization.FirstOrDefault()?.Split(" ").Last();
    }

    public static JwtSecurityToken GetJwtSecurityToken(string bearerTokenValue)
    {
        var tokenOptions = Providers.CustomConfigurationProvider.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        if (tokenOptions == null)
            throw new UnauthorizedAccessException("Token options are missing.");
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(tokenOptions.SecurityKey);

        try
        {
            tokenHandler.ValidateToken(bearerTokenValue, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken;
        }
        catch (SecurityTokenException)
        {
            throw new UnauthorizedAccessException("Token is invalid.");
        }
    }
}
