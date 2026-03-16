using FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Create;
using FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Delete;
using FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Update;
using FinanceCheckUp.Application.Features.BaseApp.Daily.Query.GetList;
using FinanceCheckUp.Application.Features.BaseApp.Daily.Query.Priority;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/daily")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DailyController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] DailyCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new DailyCreateCommand { Model = request.Model };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    [Route("{id:int}/update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateAsync([Required] int id, [FromBody] DailyUpdateRequest request, CancellationToken cancellationToken)
    {
        var command = new DailyUpdateCommand { Values = request.Model, Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:int}/delete")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteAsync([Required] int id, CancellationToken cancellationToken)
    {
        var command = new DailyDeleteCommand { Id = id };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("{year:int}/list")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListAsync([Required] int year, [FromBody] DailyGetListRequest request, CancellationToken cancellationToken)
    {
        var command = new DailyGetListQuery { DataSourceLoadOptions = request.DataSourceLoadOptions, Year = year };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("Priority")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPriorityAsync([FromBody] DailyPrioritytRequest request, CancellationToken cancellationToken)
    {
        var command = new DailyGetPriorityQuery { DataSourceLoadOptions = request.DataSourceLoadOptions };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}