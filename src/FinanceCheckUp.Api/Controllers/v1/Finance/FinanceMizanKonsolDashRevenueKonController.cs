using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/konsol/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanKonsolDashRevenueKonController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashRevenueKonOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashRevenueKonOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] MizanDashRevenueKonOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashRevenueKonOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashRevenueKonOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashRevenueKonOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
