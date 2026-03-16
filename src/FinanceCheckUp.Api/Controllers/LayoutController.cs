using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.Layouts.Query.Layout;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutByn;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutConsult;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutFinance;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutFinanceMizan;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutFirma;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutMain;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutMizan;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutQnb;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutQnbMain;
using FinanceCheckUp.Application.Features.Layouts.Query.LayoutReport;
using FinanceCheckUp.Application.Models.Requests.Layouts;
using MediatR;

namespace FinanceCheckUp.Api.Controllers;

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/layouts")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class LayoutController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    
    [HttpPost]
    [Route("layout")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutQuery(), cancellationToken);
        return Ok(result);
    }
    
    
    [HttpPost]
    [Route("layout-byn")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutBynRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutBynQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("layout-consult")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutConsultRequest request, CancellationToken cancellationToken)
    { 
        var result = await _mediator.Send(new LayoutConsultQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("layout-finance")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutFinanceRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutFinanceQuery(), cancellationToken);
        return Ok(result);
    }
  
    [HttpPost]
    [Route("layout-finance-mizan")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutFinanceMizanRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutFinanceMizanQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("layout-firma")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutFirmaRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutFirmaQuery(), cancellationToken);
        return Ok(result);
    }
    
    
    [HttpPost]
    [Route("layout-main")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutMainRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutMainQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("layout-mizan")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutMizanRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutMizanQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("layout-qnb")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutQnbRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutQnbQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("layout-qnb-main")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutQnbMainRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutQnbMainQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("layout-report")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> LayoutAsync([FromBody] LayoutReportRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LayoutReportQuery(), cancellationToken);
        return Ok(result);
    }
}




