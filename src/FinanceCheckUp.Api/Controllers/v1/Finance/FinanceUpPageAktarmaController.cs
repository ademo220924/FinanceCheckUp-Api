using FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerDateMain;
using FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.UpPageAktarma;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceUpPageAktarmaController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));



    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceUpPageAktarmaOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpPageAktarmaOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDateMain")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateMainAsync([FromBody] FinanceUpPageAktarmaOnGetSalerDateMainRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpPageAktarmaOnGetSalerDateMainQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetCheckRepPdf")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] FinanceUpPageAktarmaOnGetCheckRepPdfRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpPageAktarmaOnGetCheckRepPdfQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] FinanceUpPageAktarmaOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpPageAktarmaOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] FinanceUpPageAktarmaOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpPageAktarmaOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] FinanceUpPageAktarmaOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceUpPageAktarmaOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}
