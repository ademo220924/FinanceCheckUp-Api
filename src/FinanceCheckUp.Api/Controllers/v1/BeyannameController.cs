using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameCheck;
using FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameCreate;
using FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadBeyannameUpdate;
using FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadCreate;
using FinanceCheckUp.Application.Features.BaseApp.Beyanname.Command.MoodUploadUpdate;
using FinanceCheckUp.Application.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/beyanname")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class BeyannameController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formFileValue"></param>
    /// <param name="idValue"></param>
    /// <param name="ideValue"></param>
    /// <param name="idexmlValue"></param>
    /// <param name="captionValue"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("mood-upload-create/{idValue:int}/{ideValue}/{idexmlValue}/{captionValue}")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadCreateAsync(
        IFormFile formFileValue,
        [FromRoute] int idValue,
        [FromRoute] string ideValue,
        [FromRoute] string idexmlValue,
        [FromRoute] string captionValue,
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = new MoodUploadCreateCommand
        {
            XMlook = new XMlook
            {
                Caption = captionValue,
                id = idValue,
                ide = ideValue,
                idexml = idexmlValue,
                file = [formFileValue]
            },
            
        };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="formFileValue"></param>
    /// <param name="idValue"></param>
    /// <param name="ideValue"></param>
    /// <param name="idexmlValue"></param>
    /// <param name="captionValue"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("mood-upload-update/{idValue:int}/{ideValue}/{idexmlValue}/{captionValue}")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadUpdateAsync(
        IFormFile formFileValue,
        [FromRoute] int idValue,
        [FromRoute] string ideValue,
        [FromRoute] string idexmlValue,
        [FromRoute] string captionValue,
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = new MoodUploadUpdateCommand
        {
            XMlook = new XMlook
            {
                Caption = captionValue,
                id = idValue,
                ide = ideValue,
                idexml = idexmlValue,
                file = [formFileValue]
            },
            UserId = userId,
        };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formFileValue"></param>
    /// <param name="idValue"></param>
    /// <param name="ideValue"></param>
    /// <param name="idexmlValue"></param>
    /// <param name="captionValue"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("mood-upload-beyanname-create/{idValue:int}/{ideValue}/{idexmlValue}/{captionValue}")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadBeyannameCreateAsync(
        IFormFile formFileValue,
        [FromRoute] int idValue,
        [FromRoute] string ideValue,
        [FromRoute] string idexmlValue,
        [FromRoute] string captionValue,
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = new MoodUploadBeyannameCreateCommand
        {
            XMlook = new XMlook
            {
                Caption = captionValue,
                id = idValue,
                ide = ideValue,
                idexml = idexmlValue,
                file = [formFileValue]
            },
            UserId = userId
        };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formFileValue"></param>
    /// <param name="idValue"></param>
    /// <param name="ideValue"></param>
    /// <param name="idexmlValue"></param>
    /// <param name="captionValue"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("mood-upload-beyanname-update/{idValue:int}/{ideValue}/{idexmlValue}/{captionValue}")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadBeyannameUpdateAsync(
        IFormFile formFileValue,
        [FromRoute] int idValue,
        [FromRoute] string ideValue,
        [FromRoute] string idexmlValue,
        [FromRoute] string captionValue,
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = new MoodUploadBeyannameUpdateCommand
        {
            XMlook = new XMlook
            {
                Caption = captionValue,
                id = idValue,
                ide = ideValue,
                idexml = idexmlValue,
                file = [formFileValue]
            },
            UserId=userId,
        };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formFileValue"></param>
    /// <param name="idValue"></param>
    /// <param name="ideValue"></param>
    /// <param name="idexmlValue"></param>
    /// <param name="captionValue"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    //[CustomAuthorize(FinanceUserRoleType.Master)]
    [Route("mood-upload-beyanname-chkz")]
    [RequestSizeLimit(AppConst.DocumentMaxFileSize)]
    [RequestFormLimits(MultipartBodyLengthLimit = AppConst.MultipartBodyLengthLimit)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> MoodUploadBeyannameChkzAsync(
        IFormFile formFileValue,
        [FromQuery] int idValue,
        [FromQuery] string ideValue,
        [FromQuery] string idexmlValue,
        [FromQuery] string captionValue,
        [FromHeader(Name = "user-id")] string userId,
        CancellationToken cancellationToken)
    {
        var command = new MoodUploadBeyannameCheckCommand
        {
            XMlook = new XMlook
            {
                Caption = captionValue,
                id = idValue,
                ide = ideValue,
                idexml = idexmlValue,
                file = [formFileValue]
            },
            UserId=userId,
        };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

}