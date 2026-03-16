using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetaila.Query.FinanceDashCrmDetailaOnGet;
using FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetaila.Query.FinanceDashCrmDetailaOnGetChartRasyo;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetaila;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1.Finance;



[ApiVersion("1.0")]
[Route("api/finance/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinanceDashCrmDetailaController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] FinanceDashCrmDetailaOnGetRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmDetailaOnGetQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] FinanceDashCrmDetailaOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var command = new FinanceDashCrmDetailaOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
