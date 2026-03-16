using FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Command.Create;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetByRuleJobId;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetListByCompanyAndAccountId;
using FinanceCheckUp.Application.Features.BaseApp.Reminder.RuleJob.Query.GetListByCompanyId;
using FinanceCheckUp.Application.Models.Requests.Reminder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/reminder-rule-job")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ReminderRuleJobController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [Route("id/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var response = await _mediator.Send(new GetByRuleJobIdQuery(id));
        return Ok(response);
    }


    [HttpGet]
    [Route("company/id/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListByCompanyAsync([FromRoute] long id)
    {
        var response = await _mediator.Send(new GetListByCompanyIdQuery(id));
        return Ok(response);
    }

    [HttpPost]
    [Route("company-and-account")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetListByCompanyAndMainAccountIdAsync([FromBody] GetListByCompanyAndMainAccountIdRequest request)
    {
        var query = new GetListByCompanyAndAccountIdQuery { Model = new GetListByCompanyAndMainAccountIdRequest { AccountId = request.AccountId, CompanyId = request.CompanyId } };
        var response = await _mediator.Send(query);
        return Ok(response);
    }


    [HttpPost, Route("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRemainderRuleJobRequest request)
    {
        var command = new CreateRemainderRuleJobCommand { RuleId= request.RuleId };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}