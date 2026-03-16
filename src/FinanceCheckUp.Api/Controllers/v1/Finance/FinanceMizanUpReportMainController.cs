using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpReportMain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanUpReportMainController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanUpReportMainOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpReportMainOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] MizanUpReportMainOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpReportMainOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] MizanUpReportMainOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpReportMainOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] MizanUpReportMainOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpReportMainOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
