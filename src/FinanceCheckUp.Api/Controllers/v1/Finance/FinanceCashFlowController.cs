using FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetMarkupMarjin;
using FinanceCheckUp.Application.Models.Requests.Finance.CashFlow;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceCashFlowController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceCashFlowOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceCashFlowOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] FinanceCashFlowOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceCashFlowOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] FinanceCashFlowOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceCashFlowOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] FinanceCashFlowOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceCashFlowOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
