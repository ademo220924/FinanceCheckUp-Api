using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetCasino;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartLikid;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartMali;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartRasyoa;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartRasyob;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartRasyoc;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetDashRasyo;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceDashCrmController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceDashCrmOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCasino")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCasinoAsync([FromBody] FinanceDashCrmOnGetCasinoRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetCasinoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetOnGetChartRasyoAsync([FromBody] FinanceDashCrmOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyoa")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoaAsync([FromBody] FinanceDashCrmOnGetChartRasyoaRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetChartRasyoaQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyob")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyobAsync([FromBody] FinanceDashCrmOnGetChartRasyobRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetChartRasyobQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartRasyoc")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyocAsync([FromBody] FinanceDashCrmOnGetChartRasyocRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetChartRasyocQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartMali")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartMaliAsync([FromBody] FinanceDashCrmOnGetChartMaliRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetChartMaliQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetChartLikid")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartLikidAsync([FromBody] FinanceDashCrmOnGetChartLikidRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetChartLikidQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetDashRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetDashRasyoAsync([FromBody] FinanceDashCrmOnGetDashRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmOnGetDashRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
