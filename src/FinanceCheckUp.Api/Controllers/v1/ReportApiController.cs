using FinanceCheckUp.Application.Features.BaseApp.Report.Command.ReportPutOrderItem;
using FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetList;
using FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListDailyInOrderItem;
using FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListItem;
using FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListOrderItem;
using FinanceCheckUp.Application.Models.Requests.ReportApis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/report")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ReportApiController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("GetList")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListAsync([FromBody] ReportGetListRequest request, CancellationToken cancellationToken)
    {
        var command = new ReportGetListQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PutOrderItemAsync([FromBody] ReportPutOrderItemRequest request, CancellationToken cancellationToken)
    {
        var command = new ReportPutOrderItemCommand { ReportPutOrderItemRequest = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetListOrderItem")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListOrderItemAsync([FromQuery] GetListOrderItemRequest request, CancellationToken cancellationToken)
    {
        var command = new GetListOrderItemQuery { UserData = request.UserData };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetListItem")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListItemAsync([FromQuery] GetListItemRequest request, CancellationToken cancellationToken)
    {
        var command = new GetListItemQuery { UserData = request.UserData };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetListDailyInOrderItem")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListDailyInOrderItemAsync([FromQuery] GetListDailyInOrderItemRequest request, CancellationToken cancellationToken)
    {
        var command = new GetListDailyInOrderItemQuery { UserData = request.UserData };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}