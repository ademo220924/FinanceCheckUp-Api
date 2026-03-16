using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetCasino;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartLikid;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartMali;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartRasyoa;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetChartRasyob;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetDashRasyo;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetGraphYear;
using FinanceCheckUp.Application.Models.Requests.DashRasyo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashrasyo")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashRasyoController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashRasyoOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetCasino")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCasinoAsync([FromBody] DashRasyoOnGetCasinoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetCasinoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoAsync([FromBody] DashRasyoOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartRasyoa")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyoaAsync([FromBody] DashRasyoOnGetChartRasyoaRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetChartRasyoaQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartRasyob")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartRasyobAsync([FromBody] DashRasyoOnGetChartRasyobRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetChartRasyobQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartMali")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartMaliAsync([FromBody] DashRasyoOnGetChartMaliRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetChartMaliQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartLikid")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartLikidAsync([FromBody] DashRasyoOnGetChartLikidRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetChartLikidQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetDashRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetDashRasyoAsync([FromBody] DashRasyoOnGetDashRasyoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetDashRasyoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashRasyoOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashRasyoOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashRasyoOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}