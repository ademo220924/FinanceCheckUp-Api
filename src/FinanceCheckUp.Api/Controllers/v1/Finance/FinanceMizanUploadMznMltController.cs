using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMznMlt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance.Mizan;



[ApiVersion("1.0")]
[Route("api/finance/mizan/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanUploadMznMltController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanUploadMznMltOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUploadMznMltOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerDate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] MizanUploadMznMltOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUploadMznMltOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] MizanUploadMznMltOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUploadMznMltOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] MizanUploadMznMltOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanUploadMznMltOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}