using FinanceCheckUp.Application.Models.Responses.FileOperation;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Application.Services.Interfaces;

public interface IFileOperationService
{
    Task<GenericResult<FileOperationResponse>> UploadAsync(IFormFile imageFile, CancellationToken cancellationToken);
    Task<GenericResult<FileOperationResponse>> DownloadAsync(string imageUrl, CancellationToken cancellationToken);
    Task<GenericResult<List<ReadPdfPg>>> ReadPdfFileAsync(string fileName, CancellationToken cancellationToken);
    Task<GenericResult<List<ReadPdfMizan>>> ReadPdfFileAsync(string fileName, long compid, int nyear, byte nmonth, CancellationToken cancellationToken);
}
