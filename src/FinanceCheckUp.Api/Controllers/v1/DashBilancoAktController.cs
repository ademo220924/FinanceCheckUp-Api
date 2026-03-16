using FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGet;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.dashbilancoakt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashbilancoakt")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class dashbilancoaktController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] dashbilancoaktOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancoaktOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// //  public void OnGetSalerMain() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("saler-main")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerMainAsync([FromBody] dashbilancoaktOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancoaktOnGetSalerMainQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// //  public void OnGetPrio() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("prio")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPrioAsync([FromBody] dashbilancoaktOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancoaktOnGetPrioQuery { Request = request };
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
    public async Task<IActionResult> GetGraphYearAsync([FromBody] dashbilancoaktOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancoaktOnGetGraphYearQuery { Request = request };
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
    public async Task<IActionResult> GetGraphCompAsync([FromBody] dashbilancoaktOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancoaktOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}