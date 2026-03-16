using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital;
using System.Net;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashWorkingCapital.Query.DashWorkingCapitalOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashWorkingCapital.Query.DashWorkingCapitalOnGetMarkupMarjin;


namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanDashWorkingCapitalController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashWorkingCapitalOnGetRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new MizanDashWorkingCapitalOnGetQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashWorkingCapitalOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashWorkingCapitalOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
