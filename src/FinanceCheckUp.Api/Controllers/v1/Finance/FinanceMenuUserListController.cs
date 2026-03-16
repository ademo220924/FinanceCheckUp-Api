using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserList.Query.UserListOnGet;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;

[ApiVersion("1.0")]
[Route("api/finance/menu/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMenuUserListController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] UserListOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new UserListOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}
