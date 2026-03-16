using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListDailyInOrderItem;

public class GetListDailyInOrderItemQuery : IRequest<GenericResult<GetListDailyInOrderItemResponse>>
{
    public string UserData { get; set; }
}