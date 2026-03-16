using System.IdentityModel.Tokens.Jwt;

namespace FinanceCheckUp.Api.Middlewares;

public class TokenHeaderMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        // Token bilgisi almak için örneğin "Authorization" başlığını kontrol edebiliriz

        if (context.Request.Headers.TryGetValue("Authorization", out var token))
        {
            token = token.ToString().Replace("Bearer ", string.Empty);
            // Token bilgisini header'a ekleyebilirsiniz
            context.Request.Headers["finance-token"] = token;

            var jwt = new JwtSecurityToken(token);

            // Token'ı çöz ve user-id'yi al
            var handler = new JwtSecurityTokenHandler();

            if (handler.ReadToken(token) is JwtSecurityToken jwtToken)
            {
                var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;
                if (userId != null) //null ise exc fırlat
                {
                    // user-id'yi başlığa ekle
                    context.Request.Headers["user-id"] = userId;
                }

                var roleId = jwtToken.Claims.FirstOrDefault(c => c.Type == "role-id")?.Value;
                if (roleId != null)
                {
                    // roleId'yi başlığa ekle
                    context.Request.Headers["role-id"] = roleId;
                }
            }
        }

        // Sonraki middleware'i çağır
        await _next(context);
    }
}