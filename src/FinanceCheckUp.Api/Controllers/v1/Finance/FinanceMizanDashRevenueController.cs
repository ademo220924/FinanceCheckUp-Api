using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanDashRevenueController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashRevenueOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashRevenueOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] MizanDashRevenueOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashRevenueOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashRevenueOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
