using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGet;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetCheckRepXls;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.upcheck;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/upcheck")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UpCheckController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// //  public void OnGet() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] upcheckOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetQuery { UserId = request.UserId };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetSalerDate() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("saler-date")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerDateAsync([FromBody] upcheckOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetSalerDateQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetCheckRepPdf() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("check-rep-pdf")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] upcheckOnGetCheckRepPdfRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetCheckRepPdfQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetCheckRepXls() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("check-rep-xls")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepXlsAsync([FromBody] upcheckOnGetCheckRepXlsRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetCheckRepXlsQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// //  public void OnGetSalerYear() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("saler-year")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerYearAsync([FromBody] upcheckOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetSalerComp() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("saler-comp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] upcheckOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetSalerCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetGraphComp() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("graph-comp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] upcheckOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetGraphYear() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("graph-year")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] upcheckOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upcheckOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}