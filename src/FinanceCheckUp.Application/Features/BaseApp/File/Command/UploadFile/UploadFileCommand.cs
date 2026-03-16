using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Application.Features.BaseApp.File.Command.UploadFile;

public class UploadFileCommand : IRequest<GenericResult<FileUploadResponse>>
{
    public IFormFile ImageFile { get; set; }
}