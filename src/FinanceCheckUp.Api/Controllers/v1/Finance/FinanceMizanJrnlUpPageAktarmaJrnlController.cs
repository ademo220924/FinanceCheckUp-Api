using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetGraphCode;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetGraphCodeDel;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerDateCode;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerDateMain;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/jrnl/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanJrnlUpPageAktarmaJrnlController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanUpPageAktarmaJrnlOnGetRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new MizanUpPageAktarmaJrnlOnGetQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDateMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateMainAsync([FromBody] MizanUpPageAktarmaJrnlOnGetSalerDateMainQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDateCode")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateCodeAsync([FromBody] MizanUpPageAktarmaJrnlOnGetSalerDateCodeRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpPageAktarmaJrnlOnGetSalerDateCodeQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] MizanUpPageAktarmaJrnlOnGetSalerDateQuery request, CancellationToken cancellationToken)
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
    public async Task<IActionResult> GetSalerYearAsync([FromBody] MizanUpPageAktarmaJrnlOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUpPageAktarmaJrnlOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] MizanUpPageAktarmaJrnlOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGraphCode")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCodeAsync([FromBody] MizanUpPageAktarmaJrnlOnGetGraphCodeQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetGraphCodeDel")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCodeDelAsync([FromBody] MizanUpPageAktarmaJrnlOnGetGraphCodeDelQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

}
