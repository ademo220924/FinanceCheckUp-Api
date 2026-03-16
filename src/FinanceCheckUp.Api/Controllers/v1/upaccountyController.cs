using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGet;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerMainChk;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerMainZeta;
using FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.upaccounty;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/upaccounty")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UpAccountyController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] UpaccountyOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetQuery { UserId = request.UserId };
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
    public async Task<IActionResult> GetSalerMainChkAsync([FromBody] upaccountyOnGetSalerMainChkRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetSalerMainChkQuery { Request = request };
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
    public async Task<IActionResult> GetSalerMainZetaAsync([FromBody] upaccountyOnGetSalerMainZetaRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetSalerMainZetaQuery { Request = request };
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
    public async Task<IActionResult> GetSalerDateAsync([FromBody] upaccountyOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetSalerDateQuery { Request = request };
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
    public async Task<IActionResult> GetSalerYearAsync([FromBody] upaccountyOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetSalerYearQuery { Request = request };
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
    [Route("GetSalerComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompAsync([FromBody] upaccountyOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetSalerCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphCompAsync([FromBody] upaccountyOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetGraphCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphYearAsync([FromBody] upaccountyOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upaccountyOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}