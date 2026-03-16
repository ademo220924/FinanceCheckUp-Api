using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.File.Query.DownloadFileFromUrl;

public class DownloadFileFromUrlQuery : IRequest<GenericResult<FileDownloadFromUrlResponse>>
{
    public string ImageUrl { get; set; }
}