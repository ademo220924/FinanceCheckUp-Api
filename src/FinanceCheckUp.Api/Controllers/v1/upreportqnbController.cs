using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGet;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetCheckRep;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetGetRep;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerComp;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerDate;
using FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerYear;
using FinanceCheckUp.Application.Models.Requests.upreportqnb;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/upreportqnb")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UpReportqnbController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] upreportqnbOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetQuery { UserId = request.UserId };
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
    public async Task<IActionResult> GetSalerDateAsync([FromBody] upreportqnbOnGetSalerDateRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetSalerDateQuery { Request = request };
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
    public async Task<IActionResult> GetSalerYearAsync([FromBody] upreportqnbOnGetSalerYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetSalerYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetGetRep() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("get-rep")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGetRepAsync([FromBody] upreportqnbOnGetGetRepRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetGetRepQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// //  public void OnGetCheckRep() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("check-rep")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCheckRepAsync([FromBody] upreportqnbOnGetCheckRepRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetCheckRepQuery { Request = request };
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
    public async Task<IActionResult> GetSalerCompAsync([FromBody] upreportqnbOnGetSalerCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetSalerCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphCompAsync([FromBody] upreportqnbOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetGraphCompQuery { Request = request };
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
    public async Task<IActionResult> GetGraphYearAsync([FromBody] upreportqnbOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new upreportqnbOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}