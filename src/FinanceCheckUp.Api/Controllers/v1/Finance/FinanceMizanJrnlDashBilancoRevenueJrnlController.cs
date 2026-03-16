using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl.Query.DashBilancoRevenueJrnlOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl.Query.DashBilancoRevenueJrnlOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/jrnl/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanJrnlDashBilancoRevenueJrnlController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanDashBilancoRevenueJrnlOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoRevenueJrnlOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanDashBilancoRevenueJrnlOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanDashBilancoRevenueJrnlOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
