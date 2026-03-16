using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetCheckRepXls;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceUpBalanceController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceUpBalanceOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] FinanceUpBalanceOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] FinanceUpBalanceOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] FinanceUpBalanceOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepPdf")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] FinanceUpBalanceOnGetCheckRepPdfRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceOnGetCheckRepPdfQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepXls")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepXlsAsync([FromBody] FinanceUpBalanceOnGetCheckRepXlsRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpBalanceOnGetCheckRepXlsQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
