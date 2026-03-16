using FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetCheckUrl;
using FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTestOld;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceReportMainTestOldController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceReportMainTestOldOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceReportMainTestOldOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] FinanceReportMainTestOldOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceReportMainTestOldOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] FinanceReportMainTestOldOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceReportMainTestOldOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] FinanceReportMainTestOldOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceReportMainTestOldOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepPdf")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] FinanceReportMainTestOldOnGetCheckRepPdfRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceReportMainTestOldOnGetCheckRepPdfQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckUrl")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckUrlAsync([FromBody] FinanceReportMainTestOldOnGetCheckUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceReportMainTestOldOnGetCheckUrlQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
