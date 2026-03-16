

using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses.FileOperation;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.File.Query.ReadPdfFileMizan;
public class ReadPdfFileMizanQuery : IRequest<GenericResult<ReadPdfFileMizanQueryResponse>>
{
    public string FileName { get; set; }
    public ReadPdfFileMizanRequest Input { get; set; }

}