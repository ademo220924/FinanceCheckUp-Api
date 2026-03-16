using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalanceAkt.Query.FinanceUpBalanceAktOnGet;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalanceAkt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceUpBalanceAktController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceUpBalanceAktOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceAktOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
