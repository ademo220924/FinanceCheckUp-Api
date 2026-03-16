using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Api.Filters;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyList.Query.CompanyListOnGet;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/mizan/menu/CompanyList")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceMizanMenuCompanyListController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    //[SetUserIdFromToken]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] MizanCompanyListOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new MizanCompanyListOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}
