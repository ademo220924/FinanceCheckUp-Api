using FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Command.CreateAccountGroup;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Command.UpdateAccountGroup;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Query.GetByIdAccountGroup;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.AccountGroup.Query.GetListAccountGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/reminder-account-group")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ReminderAccountGroupController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListAsync()
    {
        var response = await _mediator.Send(new GetListAccountGroupQuery());
        return Ok(response);
    }

    [HttpGet]
    [Route("id/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var response = await _mediator.Send(new GetByIdAccountGroupQuery(id));
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerRequestExample(typeof(CreateAccountGroupCommand), typeof(CreateAccountGroupCommandExample))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<OkObjectResult> CreateAsync([FromBody] CreateAccountGroupCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [Route("")]
    [SwaggerRequestExample(typeof(UpdateAccountGroupCommand), typeof(UpdateAccountGroupCommandExample))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<OkObjectResult> UpdateAsync([FromBody] UpdateAccountGroupCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}