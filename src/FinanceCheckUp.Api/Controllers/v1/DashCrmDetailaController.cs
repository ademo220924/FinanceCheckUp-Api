using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetaila;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashcrmdetaila")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashCrmDetailaController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashCrmDetailaOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailaOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetSalerMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainAsync([FromBody] DashCrmDetailaOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailaOnGetSalerMainQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetPrio")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPrioAsync([FromBody] DashCrmDetailaOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailaOnGetPrioQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashCrmDetailaOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailaOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashCrmDetailaOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmDetailaOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}