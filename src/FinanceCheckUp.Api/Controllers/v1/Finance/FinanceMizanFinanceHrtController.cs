using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjin;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjinA;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjinB;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetChartRasyo;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanFinanceHrtController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanFinanceHrtOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanFinanceHrtOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjinA")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAAsync([FromBody] MizanFinanceHrtOnGetMarkupMarjinARequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtOnGetMarkupMarjinAQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjinB")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinBAsync([FromBody] MizanFinanceHrtOnGetMarkupMarjinBRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtOnGetMarkupMarjinBQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] MizanFinanceHrtOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
