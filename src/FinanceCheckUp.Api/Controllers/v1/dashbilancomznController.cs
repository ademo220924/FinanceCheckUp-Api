using FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGet;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetPrio;
using FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetSalerMain;
using FinanceCheckUp.Application.Models.Requests.dashbilancomzn;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashbilancomzn")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashbilancomznController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] dashbilancomznOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancomznOnGetQuery { myear = request.myear };
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
    public async Task<IActionResult> GetSalerMainAsync([FromBody] dashbilancomznOnGetSalerMainRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancomznOnGetSalerMainQuery { Request = request };
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
    public async Task<IActionResult> GetPrioAsync([FromBody] dashbilancomznOnGetPrioRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancomznOnGetPrioQuery { Request = request };
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
    public async Task<IActionResult> GetGraphYearAsync([FromBody] dashbilancomznOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancomznOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    ///// <summary>
    ///// //  public void OnGetGraphYear() 
    ///// </summary>
    ///// <param name="request"></param>
    ///// <param name="cancellationToken"></param>
    ///// <returns></returns>
    //[HttpPost]
    //[Route("chart-rasyo")]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public async Task<IActionResult> GetChartRasyoAsync([FromBody] dashbilancomznOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    //{
    //    var query = new dashbilancomznOnGetChartRasyoQuery { Request = request };
    //    var result = await _mediator.Send(query, cancellationToken);
    //    return Ok(result);
    //}

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
    public async Task<IActionResult> GetGraphCompAsync([FromBody] dashbilancomznOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new dashbilancomznOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}