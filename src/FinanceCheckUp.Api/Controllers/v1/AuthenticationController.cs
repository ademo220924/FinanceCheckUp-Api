using FinanceCheckUp.Application.Features.BaseApp.Authentication.Command.AuthenticationToken;
using FinanceCheckUp.Application.Features.BaseApp.Authentication.Query.AuthenticationLogin;
using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Client.QnbClient.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/auth")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class AuthenticationController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    /// <summary>
    /// Kullanıcı giriş işlemidir. Sistemde authentication - authorization gerektiren metotlara giriş içişn buradan login olmalı ve alınan token ile diğer süreçler ilerletmelidir.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new AuthenticationLoginQuery { MailAddress = request.MailAddress, Password = request.Password };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }



    /// <summary>
    ///Qqnb Client nesnesine ait CreateToken Parametresi ile alakalı
    /// </summary>
    /// <param name="settings"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("GetAuthorizationToken")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> AuthorizationTokenAsync([FromBody] Settings settings, CancellationToken cancellationToken)
    {
        var command = new AuthenticationTokenCommand { Settings = settings };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }




    /// <summary>
    /// Kullanıcı çıkış sayfasıdır. İşlem sonrası Token-Cooke değerleri silinir.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("logout")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LogoutAsync(CancellationToken cancellationToken)
    {
        if (HttpContext.Request.Cookies.Count > 0)
        {
            var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
            foreach (var cookie in siteCookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
        }

        await HttpContext.SignOutAsync();
        HttpContext.Session.Clear();

        //jwt de düşür
        return RedirectToPage("/Index");
    }
}