using FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGet;
using FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/upcmconsole")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UpCmconsoleController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] upcmconsoleOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new UpcmconsoleOnGetQuery { UserId = request.UserId };
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
    public async Task<IActionResult> GetSalerDateAsync([FromBody] upcmconsoleOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var query = new upcmconsoleOnGetSalerDateQuery { Request = request };
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
    public async Task<IActionResult> GetSalerYearAsync([FromBody] upcmconsoleOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upcmconsoleOnGetSalerYearQuery { Request = request };
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
    public async Task<IActionResult> GetSalerCompAsync([FromBody] upcmconsoleOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upcmconsoleOnGetSalerCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphCompAsync([FromBody] upcmconsoleOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upcmconsoleOnGetGraphCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphYearAsync([FromBody] upcmconsoleOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upcmconsoleOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}