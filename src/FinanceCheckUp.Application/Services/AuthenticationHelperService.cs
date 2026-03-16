using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.SignOperation;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Services;

public class AuthenticationHelperService : IAuthenticationHelperService
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IUserTypeManager userTypeManager;
    private readonly TokenOptions TokenOptions;
    private readonly DateTime _accessTokenExpiration;

    public AuthenticationHelperService(
        IOptions<TokenOptions> _tokenOptions,
        IUserTypeManager _userTypeManager,
        IHttpContextAccessor _httpContextAccessor
    )
    {
        TokenOptions = _tokenOptions.Value;
        _accessTokenExpiration = DateTime.Now.AddMinutes(value: TokenOptions.AccessTokenExpiration);
        userTypeManager = _userTypeManager;
        httpContextAccessor = _httpContextAccessor;
    }


    public AccessToken SignIn(User user, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(user);

        var identity = GetClaimsIdentity(user);


        var principal = new ClaimsPrincipal(identity);
        _ = httpContextAccessor.HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow,
                IsPersistent = false,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(35)
            });

        var tokenModel = CreateAccessToken(user, identity.Claims);
        httpContextAccessor.HttpContext?.Response?.Headers.Append("Authorization", "Bearer " + tokenModel.Token);

        return tokenModel;
    }

    public string GetBaseUrl()
    {
        return httpContextAccessor.HttpContext?.Request.Scheme + "://" +httpContextAccessor.HttpContext?.Request.Host.Value;
    }


    private ClaimsIdentity GetClaimsIdentity(User user)
    {
        var userType = userTypeManager.Get_Types((int)user.UserTypeId);
        var role = userType == null ? "Customer" : userType.Type;

        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        identity.AddClaim(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
        identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        identity.AddClaim(new Claim(ClaimTypes.Role, role));
        identity.AddClaim(new Claim("role-id", role));
        identity.AddClaim(new Claim("user-id", user.Id.ToString()));

        return identity;
    }



    private AccessToken CreateAccessToken(User user, IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(TokenOptions.SecurityKey));
        var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);
        var jwt = CreateJwtSecurityToken(user, signingCredential, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return new AccessToken()
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    private JwtSecurityToken CreateJwtSecurityToken(User user, SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var jwt = new JwtSecurityToken(
            issuer: TokenOptions.Issuer,
            audience: TokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, claims),
            signingCredentials: signingCredentials
            );

        return jwt;
    }

    private List<Claim> SetClaims(User user, IEnumerable<Claim> claimList)
    {
        var userType = userTypeManager.Get_Types((int)user.UserTypeId);
        var role = userType == null ? "Customer" : userType.Type;

        var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.UserGuid.ToString()),
                new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, role),
                new("role-id", role),
                new("user-id", user.Id.ToString())
            };
        claimList.Select(x => "RoleId").Distinct().ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        return claims;
    }


}