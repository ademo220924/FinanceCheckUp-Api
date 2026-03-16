using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGetKonList;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/menu/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanMenuCompanyKonsolListController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanCompanyKonsolListOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanCompanyKonsolListOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("OnGetKonList")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetKonListAsync([FromBody] MizanCompanyKonsolListOnGetKonListRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanCompanyKonsolListOnGetKonListQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}
