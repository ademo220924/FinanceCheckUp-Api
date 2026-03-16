using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/konsol/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanKonsolDashBilancoKonController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashBilancoKonOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoKonOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] MizanDashBilancoKonOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoKonOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashBilancoKonOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoKonOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
