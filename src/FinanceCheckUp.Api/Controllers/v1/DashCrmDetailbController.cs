using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetailb;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashcrmdetailb")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashCrmDetailbController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashCrmDetailbOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailbOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetSalerMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainAsync([FromBody] DashCrmDetailbOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailbOnGetSalerMainQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetPrio")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPrioAsync([FromBody] DashCrmDetailbOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailbOnGetPrioQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashCrmDetailbOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailbOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);

    }
    [HttpPost]
    [Route("OnGetRasyoChart")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRasyoChartAsync([FromBody] DashCrmDetailbOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailaOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);

    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashCrmDetailbOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailbOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);

    }
}