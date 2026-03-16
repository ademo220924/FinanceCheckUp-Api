using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetGraphYear;
using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetMarkupMarjin;
using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetPrio;
using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetSalerMain;
using FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.OnGet;
using FinanceCheckUp.Application.Models.Requests.CashFlow;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/cashflow")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class CashFlowController(IMediator mediator) : ControllerBase
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
    public async Task<IActionResult> GetAsync([FromBody] CashFlowOnGetRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new OnGetQuery(), cancellationToken);
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
    public async Task<IActionResult> GetSalerMainAsync([FromBody] GetSalerMainRequestModel request, CancellationToken cancellationToken)
    {
        var query = new GetSalerMainQuery { RequestModel = request };
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
    public async Task<IActionResult> GetPrioAsync([FromBody] GetPrioRequestModel request, CancellationToken cancellationToken)
    {
        var query = new GetPrioQuery { RequestModel = request };
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
    public async Task<IActionResult> OnGetGraphYearAsync([FromBody] GetGraphYearRequestModel request, CancellationToken cancellationToken)
    {
        var query = new GetGraphYearQuery { RequestModel = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }



    /// <summary>
    /// //  public void OnGetChartRasyo() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("chart-rasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] GetChartRasyoRequestModel request, CancellationToken cancellationToken)
    {
        var query = new GetChartRasyoQuery { RequestModel = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// //  public void OnGetChartRasyo() 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("markup-marjin")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMarkupMarjinAsync([FromBody] GetMarkupMarjinRequestModel request, CancellationToken cancellationToken)
    {
        var query = new GetMarkupMarjinQuery { RequestModel = request };
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
    public async Task<IActionResult> OnGetGraphCompAsync([FromBody] GetGraphCompRequestModel request, CancellationToken cancellationToken)
    {
        var query = new GetGraphCompQuery { RequestModel = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}