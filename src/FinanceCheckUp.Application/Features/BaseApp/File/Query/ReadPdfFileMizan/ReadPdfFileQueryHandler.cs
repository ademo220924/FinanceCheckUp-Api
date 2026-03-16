using FinanceCheckUp.Application.Models.Responses.FileOperation;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.File.Query.ReadPdfFileMizan;

public class ReadPdfFileMizanQueryHandle(IFileOperationService fileOperationService) : IRequestHandler<ReadPdfFileMizanQuery, GenericResult<ReadPdfFileMizanQueryResponse>>
{
    private readonly IFileOperationService _fileOperationService = fileOperationService ?? throw new ArgumentNullException(nameof(fileOperationService));
    public async Task<GenericResult<ReadPdfFileMizanQueryResponse>> Handle(ReadPdfFileMizanQuery request, CancellationToken cancellationToken)
    {
        var result = await _fileOperationService.ReadPdfFileAsync(request.FileName, request.Input.compid, request.Input.nyear, request.Input.nmonth, cancellationToken);
        return result.IsSuccess
            ? GenericResult<ReadPdfFileMizanQueryResponse>.Success(new ReadPdfFileMizanQueryResponse { ReadPdfMizans = result.Data })
            : GenericResult<ReadPdfFileMizanQueryResponse>.Fail(result.ProblemDetails.Detail);
    }
}