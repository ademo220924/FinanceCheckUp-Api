using FinanceCheckUp.Application.Features.BaseApp.Notification.Command.SendMail;
using FinanceCheckUp.Application.Features.BaseApp.Notification.Command.SendMailInfo;
using FinanceCheckUp.Application.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/notification")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class NotificationController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("send-mail")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> SendMailAsync([FromBody] SendMailRequest request, CancellationToken cancellationToken)
    {
        var command = new SendMailCommand { SendMailRequest = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("send-mail-info")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> SendMailInfoAsync([FromBody] SendMailRequest request, CancellationToken cancellationToken)
    {
        var command = new SendMailInfoCommand { SendMailInfoRequest = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}