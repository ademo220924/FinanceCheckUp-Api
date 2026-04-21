using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetCheckRepXls;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceNew;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanUpBalanceNewController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanUpBalanceNewOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpBalanceNewOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] MizanUpBalanceNewOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
       var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] MizanUpBalanceNewOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpBalanceNewOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] MizanUpBalanceNewOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var command = new MizanUpBalanceNewOnGetSalerCompQuery { Request = request.Request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepPdf")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] MizanUpBalanceNewOnGetCheckRepPdfQuery request, CancellationToken cancellationToken)
    {
        var command = new MizanUpBalanceNewOnGetCheckRepPdfQuery { Request = request.Request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepXls")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepXlsAsync([FromBody] MizanUpBalanceNewOnGetCheckRepXlsRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpBalanceNewOnGetCheckRepXlsQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
