using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.File.Query.DownloadFileFromUrl;

public class DownloadFileFromUrlQueryHandle(IFileOperationService fileOperationService) : IRequestHandler<DownloadFileFromUrlQuery, GenericResult<FileDownloadFromUrlResponse>>
{
    private readonly IFileOperationService _fileOperationService = fileOperationService ?? throw new ArgumentNullException(nameof(fileOperationService));
    public async Task<GenericResult<FileDownloadFromUrlResponse>> Handle(DownloadFileFromUrlQuery request, CancellationToken cancellationToken)
    {
        var result = await _fileOperationService.DownloadAsync(request.ImageUrl, cancellationToken);
        return result.IsSuccess
            ? GenericResult<FileDownloadFromUrlResponse>.Success(new FileDownloadFromUrlResponse { Image = result.Data.File })
            : GenericResult<FileDownloadFromUrlResponse>.Fail(result.ProblemDetails.Detail);
    }
}