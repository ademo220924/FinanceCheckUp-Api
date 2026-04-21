using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetDenetimRaporu;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetKontrolRaporu;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporu;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporuMizan;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporuMizanAkt;
using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinanceCheckUp.Api.Controllers.v1.Reports;

[ApiVersion("1.0")]
[Route("api/finance/CompanyReportHelper")]
[ApiController]
public class FinanceCompanyReportHelperController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("GetKontrolRaporu")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetKontrolRaporuAsync(
        [FromBody] CompanyReportHelperKontrolRaporuRequest request,
        CancellationToken cancellationToken)
    {
        var query = new CompanyReportHelperGetKontrolRaporuQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetDenetimRaporu")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetDenetimRaporuAsync(
        [FromBody] CompanyReportHelperDenetimRaporuRequest request,
        CancellationToken cancellationToken)
    {
        var query = new CompanyReportHelperGetDenetimRaporuQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetMizanRaporu")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMizanRaporuAsync(
        [FromBody] CompanyReportHelperMizanRaporuRequest request,
        CancellationToken cancellationToken)
    {
        var query = new CompanyReportHelperGetMizanRaporuQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetMizanRaporuMizan")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMizanRaporuMizanAsync(
        [FromBody] CompanyReportHelperMizanRaporuMizanRequest request,
        CancellationToken cancellationToken)
    {
        var query = new CompanyReportHelperGetMizanRaporuMizanQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("GetMizanRaporuMizanAkt")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetMizanRaporuMizanAktAsync(
        [FromBody] CompanyReportHelperMizanRaporuMizanAktRequest request,
        CancellationToken cancellationToken)
    {
        var query = new CompanyReportHelperGetMizanRaporuMizanAktQuery { Request = request };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
