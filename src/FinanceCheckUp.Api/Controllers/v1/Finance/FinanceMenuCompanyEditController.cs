using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGetSalerCity;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGetSalerEnteg;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyEdit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/menu/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMenuCompanyEditController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] CompanyEditOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyEditOnGetQuery {  Id= request.Id };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerEnteg")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerEntegAsync([FromBody] CompanyEditOnGetSalerEntegRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyEditOnGetSalerEntegQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerCity")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCityAsync([FromBody] CompanyEditOnGetSalerCityRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyEditOnGetSalerCityQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
