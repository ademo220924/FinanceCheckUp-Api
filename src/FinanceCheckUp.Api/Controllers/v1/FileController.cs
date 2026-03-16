using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Features.BaseApp.File.Command.UploadFile;
using FinanceCheckUp.Application.Features.BaseApp.File.Query.DownloadFileFromUrl;
using FinanceCheckUp.Application.Features.BaseApp.File.Query.ReadPdfFile;
using FinanceCheckUp.Application.Features.BaseApp.File.Query.ReadPdfFileMizan;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;



[ApiVersion("1.0")]
[Route("api/file")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FileController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    // DownloadImageFromUrl

    //UploadVideoMain

    [HttpGet]
    [Route("download-file")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DownloadImageFromUrlAsync([FromQuery] DownloadImageFromUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new DownloadFileFromUrlQuery { ImageUrl = request.ImageUrl };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
            return File(result.Data.Image, MediaTypeNames.Image.Jpeg);
        return NotFound(result.ProblemDetails.Detail);
    }

    [HttpPost]
    [Route("upload-file")]
    [RequestSizeLimit(AppConst.RequestSizeLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UploadImageAsync(IFormFile formFile, [FromQuery] UploadImageRequest request, CancellationToken cancellationToken)
    {
        var command = new UploadFileCommand { ImageFile = formFile };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
            return File(result.Data.Image, MediaTypeNames.Image.Jpeg);
        return NotFound(result.ProblemDetails.Detail);
    }


    [HttpPost]
    [Route("read-pdf-file")]
    [RequestSizeLimit(AppConst.RequestSizeLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ReadPdfFileAsync(IFormFile formFile, CancellationToken cancellationToken)
    {
        var command = new ReadPdfFileQuery { FileName = formFile.FileName };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
            return Ok(result);
        return NotFound(result.ProblemDetails.Detail);
    }


    [HttpPost]
    [Route("read-pdf-file-mizan")]
    [RequestSizeLimit(AppConst.RequestSizeLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ReadPdfFileMizanAsync(IFormFile formFile, [FromQuery] ReadPdfFileMizanRequest request, CancellationToken cancellationToken)
    {
        var command = new ReadPdfFileMizanQuery { FileName = formFile.FileName, Input = request };
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
            return Ok(result);
        return NotFound(result.ProblemDetails.Detail);
    }

    //ReadPdfFile
    //public List<ReadPdfPg> ReadPdfFile(string fileName)

}
