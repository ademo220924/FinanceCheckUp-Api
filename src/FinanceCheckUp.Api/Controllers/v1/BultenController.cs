using FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Create;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Update;
using IMapper = AutoMapper.IMapper;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/bulten")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class BultenController(IMediator mediator,IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    //public JsonResult FormSubmita(bulten model)

    
    [HttpPost]
    [Route("save")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] BultenCreateRequest request, 
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<BultenCreateRequest, BultenCreateCommand>(request);
       // command.UserId = userId;
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    
    [HttpPost]
    [Route("update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] BultenUpdateRequest request, 
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<BultenUpdateRequest, BultenUpdateCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}