using FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.DashWorkingCapital;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashworkingcapital")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashWorkingCapitalController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashWorkingCapitalOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashWorkingCapitalOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetSalerMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainAsync([FromBody] DashWorkingCapitalOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new DashWorkingCapitalOnGetSalerMainQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetPrio")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPrioAsync([FromBody] DashWorkingCapitalOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new DashWorkingCapitalOnGetPrioQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashWorkingCapitalOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashWorkingCapitalOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashWorkingCapitalOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashWorkingCapitalOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}