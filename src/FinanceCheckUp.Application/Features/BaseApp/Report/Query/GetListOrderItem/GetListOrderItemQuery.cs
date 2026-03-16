using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetListOrderItem;

public class GetListOrderItemQuery : IRequest<GenericResult<GetListOrderItemResponse>>
{
    public string UserData { get; set; }
}