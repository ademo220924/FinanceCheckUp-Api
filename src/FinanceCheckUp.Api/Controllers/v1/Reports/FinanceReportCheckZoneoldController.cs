using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMII;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMIII;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMIV;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMizanII;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMizanIII;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMizanIV;
using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinanceCheckUp.Api.Controllers.v1.Reports;

[ApiVersion("1.0")]
[Route("api/finance/ReportCheckZoneold")]
[ApiController]
public class FinanceReportCheckZoneoldController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("GetReportMizanII")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMizanIIAsync(
        [FromBody] ReportCheckZoneoldStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneoldGetReportMizanIIQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportMizanIII")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMizanIIIAsync(
        [FromBody] ReportCheckZoneoldStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneoldGetReportMizanIIIQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportMizanIV")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMizanIVAsync(
        [FromBody] ReportCheckZoneoldStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneoldGetReportMizanIVQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportMII")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMIIAsync(
        [FromBody] ReportCheckZoneoldStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneoldGetReportMIIQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportMIII")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMIIIAsync(
        [FromBody] ReportCheckZoneoldStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneoldGetReportMIIIQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportMIV")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMIVAsync(
        [FromBody] ReportCheckZoneoldStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneoldGetReportMIVQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
