using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashLiquidity.Query.DashLiquidityOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashLiquidity.Query.DashLiquidityOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanDashLiquidityController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashLiquidityOnGetRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new MizanDashLiquidityOnGetQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashLiquidityOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
