using FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilancoJrnl.Query.FinanceDashBilancoJrnlOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilancoJrnl.Query.FinanceDashBilancoJrnlOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilancoJrnl;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceDashBilancoJrnlController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceDashBilancoJrnlOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashBilancoJrnlOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] FinanceDashBilancoJrnlOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashBilancoJrnlOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
