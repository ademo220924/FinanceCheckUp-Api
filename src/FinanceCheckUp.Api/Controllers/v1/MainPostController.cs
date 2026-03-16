using FinanceCheckUp.Application.Features.BaseApp.General.TblZoneError.Command.CreateOrUpdate;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/main-post")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class MainPostController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// MainPostController=> FormSubmitError
    /// TBLErrzone tablosuna kayıt ekleme veya güncelleme işlemidir
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("tblzone-error-create-or-update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> TblErrorZoneCreateOrUpdateAsync([FromBody] TblZoneErrorCreateOrUpdateRequest request, CancellationToken cancellationToken)
    {
        var command = new TblZoneErrorCreateOrUpdateCommand { DataViewerError = request.DataViewerError };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    ///  MainPostController=> FormSubmitCheck
    /// TblZoneError tablosuna kayıt ekleme işlemidir
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("tbl-wzone-create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> TblWzoneCreateAsync([FromBody] TblZoneErrorCreateOrUpdateRequest request, CancellationToken cancellationToken)
    {
        var command = new TblZoneErrorCreateOrUpdateCommand { DataViewerError = request.DataViewerError };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}