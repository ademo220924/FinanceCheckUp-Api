using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerCity;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerEnteg;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsol;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/menu/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMenuCompanyKonsolController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] CompanyKonsolOnGetRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CompanyKonsolOnGetQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerEnteg")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerEntegAsync([FromBody] CompanyKonsolOnGetSalerEntegRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyKonsolOnGetSalerEntegQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerCity")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCityAsync([FromBody] CompanyKonsolOnGetSalerCityRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyKonsolOnGetSalerCityQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
