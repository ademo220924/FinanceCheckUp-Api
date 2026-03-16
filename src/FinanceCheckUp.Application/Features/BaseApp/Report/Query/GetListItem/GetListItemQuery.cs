using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListItem;

public class GetListItemQuery : IRequest<GenericResult<GetListItemResponse>>
{
    public string UserData { get; set; }
}