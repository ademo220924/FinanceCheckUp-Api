using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGet;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetCheckRepPdf;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetCheckRepXls;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerMainChk;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerMainZeta;
using FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/upaccount")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UpAccountController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] UpaccountOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetQuery { UserId = request.UserId };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// //  public void OnGetSalerMainChk() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("saler-main-chk")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainChkAsync([FromBody] upaccountOnGetSalerMainChkRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetSalerMainChkQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// //  public void OnGetSalerMainZeta() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("saler-main-zeta")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainZetaAsync([FromBody] upaccountOnGetSalerMainZetaRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetSalerMainZetaQuery { Request = request };
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
    public async Task<IActionResult> GetSalerDateAsync([FromBody] upaccountOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetSalerDateQuery { Request = request };
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
    public async Task<IActionResult> GetSalerYearAsync([FromBody] upaccountOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetSalerYearQuery { Request = request };
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
    public async Task<IActionResult> GetSalerCompAsync([FromBody] upaccountOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetSalerCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphCompAsync([FromBody] upaccountOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetGraphCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphYearAsync([FromBody] upaccountOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetGraphYearQuery { Request = request };
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
    public async Task<IActionResult> GetCheckRepPdfAsync([FromBody] upaccountOnGetCheckRepPdfRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetCheckRepPdfQuery { Request = request };
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
    public async Task<IActionResult> GetCheckRepXlsAsync([FromBody] upaccountOnGetCheckRepXlsRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountOnGetCheckRepXlsQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}