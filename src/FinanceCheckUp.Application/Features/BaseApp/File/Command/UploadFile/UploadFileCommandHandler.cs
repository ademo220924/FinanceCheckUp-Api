using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.File.Command.UploadFile;

public class UploadFileCommandHandle(IFileOperationService fileOperationService) : IRequestHandler<UploadFileCommand, GenericResult<FileUploadResponse>>
{
    private readonly IFileOperationService _fileOperationService = fileOperationService ?? throw new ArgumentNullException(nameof(fileOperationService));

    public async Task<GenericResult<FileUploadResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var result = await _fileOperationService.UploadAsync(request.ImageFile, cancellationToken);
        return result.IsSuccess
            ? GenericResult<FileUploadResponse>.Success(new FileUploadResponse { Image = result.Data.File })
            : GenericResult<FileUploadResponse>.Fail(result.ProblemDetails.Detail);
    }
}