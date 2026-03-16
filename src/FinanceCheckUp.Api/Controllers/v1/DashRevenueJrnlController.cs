using FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetMarkupMarjin;
using FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.DashRevenueJrnl;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashrevenuejrnl")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashRevenueJrnlController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashRevenueJrnlOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRevenueJrnlOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetSalerMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainAsync([FromBody] DashRevenueJrnlOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRevenueJrnlOnGetSalerMainQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetPrio")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPrioAsync([FromBody] DashRevenueJrnlOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRevenueJrnlOnGetPrioQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashRevenueJrnlOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRevenueJrnlOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashRevenueJrnlOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRevenueJrnlOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] DashRevenueJrnlOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRevenueJrnlOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}