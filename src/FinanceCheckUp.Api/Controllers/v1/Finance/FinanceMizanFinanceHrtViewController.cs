using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView;
using System.Net;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetMarkupMarjin;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetEbitMarjin;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetWorkingCapital;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetDonemselKarZarar;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetRevenue;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetGrossProfit;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetGraphZet;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanFinanceHrtViewController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanFinanceHrtViewOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetMarkupMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] MizanFinanceHrtViewOnGetMarkupMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetMarkupMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetEbitMarjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetEbitMarjinAsync([FromBody] MizanFinanceHrtViewOnGetEbitMarjinRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetEbitMarjinQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetWorkingCapital")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetWorkingCapitalAsync([FromBody] MizanFinanceHrtViewOnGetWorkingCapitalRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetWorkingCapitalQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetDonemselKarZarar")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetDonemselKarZararAsync([FromBody] MizanFinanceHrtViewOnGetDonemselKarZararRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetDonemselKarZararQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetRevenue")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRevenueAsync([FromBody] MizanFinanceHrtViewOnGetRevenueRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetRevenueQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGrossProfit")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGrossProfitAsync([FromBody] MizanFinanceHrtViewOnGetGrossProfitRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetGrossProfitQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGraphZet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphZetAsync([FromBody] MizanFinanceHrtViewOnGetGraphZetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanFinanceHrtViewOnGetGraphZetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
