using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Models.SignOperation;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceCheckUp.Api.Filters;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizeAttribute(FinanceUserRoleType requiredRole) : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers.Authorization.FirstOrDefault();
        var token = authorizationHeader?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        try
        {
            var jwtToken = TokenHelper.GetJwtSecurityToken(token);
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (roleClaim == null || roleClaim.Value != requiredRole.ToString())
            {
                context.Result = new ForbidResult();
            }
        }
        catch (SecurityTokenException)
        {
            context.Result = new UnauthorizedResult();
        }
        catch (Exception)
        {
            context.Result = new ForbidResult();
        }
    }
}