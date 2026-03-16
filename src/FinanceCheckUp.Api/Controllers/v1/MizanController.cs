using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMzn;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeck;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeckFileCreate;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadMznCkeckFileUpdate;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUploadUpdateMzn;
using FinanceCheckUp.Application.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdateBalance;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarma;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaMzn;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelected;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelectedByn;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelectedMzn;
using FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesmm;
using FinanceCheckUp.Application.Models.Requests.Mizan;
using FinanceCheckUp.Application.Models.Responses.Mizan;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/mizan")]
[ApiController]
public class MizanController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost]
    [Route("upload-multiple-test")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> TestMultipleUploadFile(List<IFormFile> files, CancellationToken cancellationToken)
    {
        if (files == null || files.Count == 0)
            return BadRequest("No files were uploaded.");

        foreach (var file in files)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles", file.FileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream, cancellationToken);
        }

        return Ok(new { count = files.Count, message = "Files uploaded successfully." });
    }


    /// <summary>
    ///  moodUploadMznCkeckPDFUpdate
    /// </summary>
    /// <param name="files"></param>
    /// <param name="id"></param>
    /// <param name="ide"></param>
    /// <param name="ideXml"></param>
    /// <param name="caption"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("moodUploadMznCkeckPDFUpdate")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadMznCkeckFileUpdateAsync(
        List<IFormFile> files,
        [FromQuery] int id,
        [FromQuery] string ide,
        [FromQuery] string ideXml,
        [FromQuery] string caption,
        CancellationToken cancellationToken)
    {
        if (files is null)
            throw new ArgumentNullException(nameof(files));


        var command = new MoodUploadMznCkeckFileUpdateCommand(xMlook: new XMlook
        {
            id = id,
            ide = ide,
            idexml = ideXml,
            Caption = caption
        });
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    /// <summary>
    ///  moodUploadMznCkeckPDF-Create
    /// </summary>
    /// <param name="files"></param>
    /// <param name="id"></param>
    /// <param name="ide"></param>
    /// <param name="ideXml"></param>
    /// <param name="caption"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("moodUploadMznCkeckPDF-Create")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadMznCkeckFileCreateAsync(
        List<IFormFile> files,
        [FromQuery] int id,
        [FromQuery] string ide,
        [FromQuery] string ideXml,
        [FromQuery] string caption,
        CancellationToken cancellationToken)
    {
        if (files is null)
            throw new ArgumentNullException(nameof(files));

        var command = new MoodUploadMznCkeckFileCreateCommand(xMlook: new XMlook
        {
            id = id,
            ide = ide,
            idexml = ideXml,
            Caption = caption
        });
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    /// <summary>
    ///  moodUploadMznCkeck
    /// </summary>
    /// <param name="files"></param>
    /// <param name="id"></param>
    /// <param name="ide"></param>
    /// <param name="ideXml"></param>
    /// <param name="caption"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("moodUploadMznCkeck")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadMznCkeckAsync(
        List<IFormFile> files,
        [FromQuery] int id,
        [FromQuery] string ide,
        [FromQuery] string ideXml,
        [FromQuery] string caption,
        CancellationToken cancellationToken)
    {
        if (files is null)
            throw new ArgumentNullException(nameof(files));

        var command = new MoodUploadMznCkeckCommand(xMlook: new XMlook
        {
            id = id,
            ide = ide,
            idexml = ideXml,
            Caption = caption
        });
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    /// <summary>
    ///  moodUploadMzn
    /// </summary>
    /// <param name="files"></param>
    /// <param name="id"></param>
    /// <param name="ide"></param>
    /// <param name="ideXml"></param>
    /// <param name="caption"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("moodUploadMzn")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadMznAsync(
        List<IFormFile> files,
        [FromQuery] int id,
        [FromQuery] string ide,
        [FromQuery] string ideXml,
        [FromQuery] string caption,
        CancellationToken cancellationToken)
    {
        if (files is null)
            throw new ArgumentNullException(nameof(files));

        var command = new MoodUploadMznCommand(xMlook: new XMlook
        {
            id = id,
            ide = ide,
            idexml = ideXml,
            Caption = caption
        });
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    /// <summary>
    ///  moodUploadUpdateMzn
    /// </summary>
    /// <param name="files"></param>
    /// <param name="id"></param>
    /// <param name="ide"></param>
    /// <param name="ideXml"></param>
    /// <param name="caption"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("moodUploadUpdateMzn")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadUpdateMznAsync(
        List<IFormFile> files,
        [FromQuery] int id,
        [FromQuery] string ide,
        [FromQuery] string ideXml,
        [FromQuery] string caption,
        CancellationToken cancellationToken)
    {
        if (files is null)
            throw new ArgumentNullException(nameof(files));

        var command = new MoodUploadUpdateMznCommand(xMlook: new XMlook
        {
            id = id,
            ide = ide,
            idexml = ideXml,
            Caption = caption
        });
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
    [HttpPost]
    [Route("moodUpdateBalance")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadMznAsync(
        [FromBody] MoodUpdateBalanceRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new MoodUpdateBalanceCommand(request.PageIndex);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("moodUpdatesaktarma")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUpdatesAktarmaAsync(
        [FromBody] MoodUpdatesAktarmaRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new MoodUpdatesAktarmaCommand(request.PageIndex);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
    [HttpPost]
    [Route("moodUpdatesaktarmamzn")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadMznAsync(
        [FromBody] MoodUpdatesAktarmaMznRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new  MoodUpdatesAktarmaMznCommand(request.PageIndex);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
        
    [HttpPost]
    [Route("moodUpdatesaktarmaselected")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUpdatesAktarmaSelectedAsync(
        [FromBody] MoodUpdatesAktarmaSelectedRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new MoodUpdatesAktarmaSelectedCommand(request.PageIndex);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
    [HttpPost]
    [Route("moodUpdatesaktarmaselectedbyn")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUpdatesAktarmaSelectedBynAsync(
        [FromBody] MoodUpdatesAktarmaSelectedBynRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new MoodUpdatesAktarmaSelectedBynCommand(request.PageIndex);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
    
    [HttpPost]
    [Route("moodUpdatesaktarmaselectedmzn")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUpdatesAktarmaSelectedMznAsync(
        [FromBody] MoodUpdatesAktarmaSelectedMznRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new MoodUpdatesAktarmaSelectedMznCommand(request.XMlookUpdate);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    
    [HttpPost]
    [Route("moodUpdatesmm")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUpdateSmmAsync(
        [FromBody] MoodUpdateSmmRequest request,
        CancellationToken cancellationToken)
    {
     
        var command = new MoodUpdateSmmCommand(request.PageIndex);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}