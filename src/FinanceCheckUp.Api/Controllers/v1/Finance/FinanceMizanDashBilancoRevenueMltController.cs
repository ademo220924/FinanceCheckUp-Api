using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoRevenueMlt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanDashBilancoRevenueMltController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashBilancoRevenueMltOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoRevenueMltOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGetChartRasyoAsync([FromBody] MizanDashBilancoRevenueMltOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoRevenueMltOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashBilancoRevenueMltOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoRevenueMltOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
