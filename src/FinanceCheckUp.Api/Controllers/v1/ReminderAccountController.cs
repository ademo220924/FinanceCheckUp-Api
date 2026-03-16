using FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Command.CreateAccount;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Command.UpdateAccount;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetByIdAccount;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListAccount;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListByAccountGroupId;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Account.Query.GetListByAccountType;
using FinanceCheckUp.Application.Models.Requests.Reminder.Account;
using FinanceCheckUp.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/reminder-account")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ReminderAccountController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListAsync()
    {
        var response = await _mediator.Send(new GetListAccountQuery());
        return Ok(response);
    }

    [HttpGet]
    [Route("id/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var response = await _mediator.Send(new GetByIdAccountQuery(id));
        return Ok(response);
    }

    [HttpGet]
    [Route("account-group/id/{accountGroupId:long}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListByAccountGroupAsync([FromRoute] int accountGroupId)
    {
        var response = await _mediator.Send(new GetListByAccountGroupIdQuery(accountGroupId));
        return Ok(response);
    }

    [HttpGet]
    [Route("account-type/{accountType}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListByPaymentTypeAsync([FromRoute] AccountType accountType)
    {
        var response = await _mediator.Send(new GetListByAccountTypeQuery(accountType));
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    [SwaggerRequestExample(typeof(CreateAccountCommand), typeof(CreateMainAccountCommandExample))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<OkObjectResult> CreateAsync([FromBody] ReminderAccountCreateRequest request)
    {
        var command = new CreateAccountCommand { Model = request };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [Route("")]
    [SwaggerRequestExample(typeof(UpdateAccountCommand), typeof(UpdateMainAccountCommandExample))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<OkObjectResult> UpdateAsync([FromBody] ReminderAccountUpdateRequest request)
    {
        var command = new UpdateAccountCommand{Model = request };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}