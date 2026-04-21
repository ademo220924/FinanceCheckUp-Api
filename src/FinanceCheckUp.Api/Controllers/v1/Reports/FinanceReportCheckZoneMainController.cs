using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReport;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReportFour;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReportMizan;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReportMizanFour;
using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinanceCheckUp.Api.Controllers.v1.Reports;

[ApiVersion("1.0")]
[Route("api/finance/ReportCheckZoneMain")]
[ApiController]
public class FinanceReportCheckZoneMainController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("GetReportMizanFour")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMizanFourAsync(
        [FromBody] ReportCheckZoneMainStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneMainGetReportMizanFourQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportMizan")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportMizanAsync(
        [FromBody] ReportCheckZoneMainStandardRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneMainGetReportMizanQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportAsync(
        [FromBody] ReportCheckZoneMainWithYearListRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneMainGetReportQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetReportFour")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetReportFourAsync(
        [FromBody] ReportCheckZoneMainWithYearListRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceReportCheckZoneMainGetReportFourQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
