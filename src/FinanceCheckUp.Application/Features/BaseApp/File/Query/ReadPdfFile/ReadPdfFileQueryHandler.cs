using FinanceCheckUp.Application.Models.Responses.FileOperation;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.File.Query.ReadPdfFile;

public class ReadPdfFileQueryHandle(IFileOperationService fileOperationService) : IRequestHandler<ReadPdfFileQuery, GenericResult<ReadPdfFileQueryResponse>>
{
    private readonly IFileOperationService _fileOperationService = fileOperationService ?? throw new ArgumentNullException(nameof(fileOperationService));
    public async Task<GenericResult<ReadPdfFileQueryResponse>> Handle(ReadPdfFileQuery request, CancellationToken cancellationToken)
    {
        var result = await _fileOperationService.ReadPdfFileAsync(request.FileName, cancellationToken);
        return result.IsSuccess
            ? GenericResult<ReadPdfFileQueryResponse>.Success(new ReadPdfFileQueryResponse { ReadPdfPgs = result.Data })
            : GenericResult<ReadPdfFileQueryResponse>.Fail(result.ProblemDetails.Detail);
    }
}