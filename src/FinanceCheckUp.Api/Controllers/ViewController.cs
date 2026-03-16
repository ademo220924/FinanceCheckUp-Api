using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;
using FinanceCheckUp.Application.Features.Layouts.Query.Layout;
using FinanceCheckUp.Application.Features.Views.Query.GetStockHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Api.Controllers;

 

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/views")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class ViewController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [Route("stock-history")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> StockHistoryAsync([FromQuery] string serialNumber, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetStockHistoryQuery(){SerialNumber= serialNumber}, cancellationToken);
        return Ok(result);
    }
}