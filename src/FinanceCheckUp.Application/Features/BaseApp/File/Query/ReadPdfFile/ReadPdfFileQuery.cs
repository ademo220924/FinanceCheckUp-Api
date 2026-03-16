

using FinanceCheckUp.Application.Models.Responses.FileOperation;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.File.Query.ReadPdfFile;
public class ReadPdfFileQuery : IRequest<GenericResult<ReadPdfFileQueryResponse>>
{
    public string FileName { get; set; }
}