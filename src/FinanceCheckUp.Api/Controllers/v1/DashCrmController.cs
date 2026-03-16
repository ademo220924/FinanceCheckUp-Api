using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGet;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetCasino;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartLikid;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartMali;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyo;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyoa;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyob;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyoc;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyod;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetDashRasyo;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetGraphComp;
using FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetGraphYear;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/dashcrm")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class DashCrmController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("OnGet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync([FromBody] DashCrmOnGetRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetCasino")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCasinoAsync([FromBody] DashCrmOnGetCasinoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetCasinoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRasyoAsync([FromBody] DashCrmOnGetChartRasyoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetChartRasyoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetRasyoa")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRasyoaAsync([FromBody] DashCrmOnGetChartRasyoaRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetChartRasyoaQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetRasyob")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRasyobAsync([FromBody] DashCrmOnGetChartRasyobRequest request, CancellationToken cancellationToken)
    {

        var query = new DashCrmOnGetChartRasyobQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetRasyod")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRasyodAsync([FromBody] DashCrmOnGetChartRasyodRequest request, CancellationToken cancellationToken)
    {


        var query = new DashCrmOnGetChartRasyodQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetRasyoc")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetRasyocAsync([FromBody] DashCrmOnGetChartRasyocRequest request, CancellationToken cancellationToken)

    {
        var query = new DashCrmOnGetChartRasyocQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartMali")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartMaliAsync([FromBody] DashCrmOnGetChartMaliRequest request, CancellationToken cancellationToken)
    {


        var query = new DashCrmOnGetChartMaliQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetChartLikid")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetChartLikidAsync([FromBody] DashCrmOnGetChartLikidRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetChartLikidQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetDashRasyo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetDashRasyoAsync([FromBody] DashCrmOnGetDashRasyoRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetDashRasyoQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphYear")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphYearAsync([FromBody] DashCrmOnGetGraphYearRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetGraphYearQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    [HttpPost]
    [Route("OnGetGraphComp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetGraphCompAsync([FromBody] DashCrmOnGetGraphCompRequest request, CancellationToken cancellationToken)
    {
        var query = new DashCrmOnGetGraphCompQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}