using FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.DashLiquidity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashliquidity")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashLiquidityController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashLiquidityOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashLiquidityOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetSalerMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainAsync([FromBody] DashLiquidityOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new DashLiquidityOnGetSalerMainQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetPrio")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPrioAsync([FromBody] DashLiquidityOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new DashLiquidityOnGetPrioQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashLiquidityOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashLiquidityOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashLiquidityOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashLiquidityOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }


}