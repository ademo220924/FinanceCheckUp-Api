using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenueMain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/aktarma/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceAktarmaDashRevenueMainController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] AktarmaDashRevenueMainOnGetRequest request, CancellationToken cancellationToken)
    {
        return Ok();
        //var command = new AktarmaDashRevenueMainOnGetQuery { Request = request };
        //var result = await _mediator.Send(command, cancellationToken);
        //return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] AktarmaDashRevenueMainOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        return Ok();
        //var command = new AktarmaDashRevenueMainOnGetGraphYearQuery { Request = request };
        //var result = await _mediator.Send(command, cancellationToken);
        //return Ok(result);
    }


    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] AktarmaDashRevenueMainOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        return Ok();
        //var command = new AktarmaDashRevenueMainOnGetMarkupMarjinQuery { Request = request };
        //var result = await _mediator.Send(command, cancellationToken);
        //return Ok(result);
    }
}
