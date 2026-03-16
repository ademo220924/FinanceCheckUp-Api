using FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjin;
using FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjinA;
using FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjinB;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtHor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceHrtHorController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceFinanceHrtHorOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceFinanceHrtHorOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] FinanceFinanceHrtHorOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceFinanceHrtHorOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] FinanceFinanceHrtHorOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceFinanceHrtHorOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjinA")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAAsync([FromBody] FinanceFinanceHrtHorOnGetMarkupMarjinARequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceFinanceHrtHorOnGetMarkupMarjinAQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjinB")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinBAsync([FromBody] FinanceFinanceHrtHorOnGetMarkupMarjinBRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceFinanceHrtHorOnGetMarkupMarjinBQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
