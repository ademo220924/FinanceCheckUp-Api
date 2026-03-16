using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetCheckUrl;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanReportMainTestMizanOldController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanReportMainTestMizanOldOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanReportMainTestMizanOldOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] MizanReportMainTestMizanOldOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanReportMainTestMizanOldOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] MizanReportMainTestMizanOldOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanReportMainTestMizanOldOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] MizanReportMainTestMizanOldOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanReportMainTestMizanOldOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepPdf")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] MizanReportMainTestMizanOldOnGetCheckRepPdfRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanReportMainTestMizanOldOnGetCheckRepPdfQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckUrl")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckUrlAsync([FromBody] MizanReportMainTestMizanOldOnGetCheckUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanReportMainTestMizanOldOnGetCheckUrlQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
