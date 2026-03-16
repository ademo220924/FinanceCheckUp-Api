using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGetSalerCity;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGetSalerEnteg;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyEdit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/menu/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanMenuCompanyEditController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanCompanyEditOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanCompanyEditOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerEnteg")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerEntegAsync([FromBody] MizanCompanyEditOnGetSalerEntegRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanCompanyEditOnGetSalerEntegQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetSalerCity")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSalerCityAsync([FromBody] MizanCompanyEditOnGetSalerCityRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanCompanyEditOnGetSalerCityQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}
