using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ComReport.Query.Getreport;
using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinanceCheckUp.Api.Controllers.v1.Reports;

[ApiVersion("1.0")]
[Route("api/finance/ComReport")]
[ApiController]
public class FinanceComReportController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("Getreport")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetreportAsync(
        [FromBody] ComReportGetreportRequest request,
        CancellationToken cancellationToken)
    {
        var query = new FinanceComReportGetreportQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
