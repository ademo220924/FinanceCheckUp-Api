using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetSalerCity;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetSalerCompany;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetUser;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserEdit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/menu/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMenuUserEditController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] UserEditOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new UserEditOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetSalerCity")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCityAsync([FromBody] UserEditOnGetSalerCityRequest request, CancellationToken cancellationToken)
    {
        var command = new UserEditOnGetSalerCityQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerCompany")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCompanyAsync([FromBody] UserEditOnGetSalerCompanyRequest request, CancellationToken cancellationToken)
    {
        var command = new UserEditOnGetSalerCompanyQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetUser")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetUserAsync([FromBody] UserEditOnGetUserRequest request, CancellationToken cancellationToken)
    {
        var command = new UserEditOnGetUserQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
