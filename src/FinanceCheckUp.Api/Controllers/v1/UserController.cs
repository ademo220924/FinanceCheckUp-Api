using AutoMapper;
using FinanceCheckUp.Application.Features.BaseApp.Users.Command.Create;
using FinanceCheckUp.Application.Features.BaseApp.Users.Command.Delete;
using FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserCompanyUpdate;
using FinanceCheckUp.Application.Features.BaseApp.Users.Command.UserPasswordChange;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Users.Query.GetType;
using FinanceCheckUp.Application.Features.BaseApp.Users.Query.GetTypes;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/user")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class UserController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    /// <summary>
    /// FormSubmitPass(HhvnUsersView model)
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("change-password")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] UserPasswordChangeRequest request, CancellationToken cancellationToken)
    {
        var command = new UserPasswordChangeCommand { Id = request.Id, Password = request.Password, UserId = request.UserId };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("update-companies")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UserCompanyUpdateAsync([FromBody] UserCompanyUpdateRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UserCompanyUpdateRequest, UserCompanyUpdateCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpDelete]
    [Route("delete/id/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteAsync([FromHeader(Name = "user-id")] string userId, long id, CancellationToken cancellationToken)
    {
        var command = new UserDeleteCommand { Id = id, UserId= userId };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("crete")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request,CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand { Model = request, UserId = request.UserId };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] UserCompanyUpdateRequest request, CancellationToken cancellationToken)
    {
        var command = new UserCompanyUpdateCommand { Model = request, UserId = request.UserId };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
    [HttpGet]
    [Route("types")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetTypeAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UserTypesQuery(), cancellationToken);
        return Ok(result);
    }
    
     
    [HttpGet]
    [Route("type/id/{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetTypeAsync([FromRoute] int id,CancellationToken cancellationToken)
    {
        var query = new UserTypeQuery { Id = id};
        var result = await _mediator.Send(new UserTypeQuery(), cancellationToken);
        return Ok(result);
    }
}