using FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Command.CreateRemainderRule;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Command.Generate;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetByIdRule;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetByPeriodTypeRules;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.Rule.Query.GetListRules;
using FinanceCheckUp.Application.Models.Requests.Reminder;
using FinanceCheckUp.Domain.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/reminder-rule")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ReminderRuleController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListAsync()
    {
        var response = await _mediator.Send(new GetListRuleQuery());
        return Ok(response);
    }

    [HttpGet]
    [Route("id/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var response = await _mediator.Send(new GetByIdQuery(id));
        return Ok(response);
    }

    [HttpGet]
    [Route("period-type/{periodType}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListByPeriodTypeAsync([FromRoute] PeriodType periodType)
    {
        var response = await _mediator.Send(new GetByPeriodTypeRuleQuery(periodType));
        return Ok(response);
    }


    [HttpPost, Route("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRemainderRuleRequest request)
    {
        var command = new CreateRemainderRuleCommand { Model = request };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost, Route("generate")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GenerateAsync([FromBody] GenerateRemainderRuleRequest request)
    {
        var command = new GenerateRemainderRuleCommand { ReminderRules = request.ReminderRules };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}