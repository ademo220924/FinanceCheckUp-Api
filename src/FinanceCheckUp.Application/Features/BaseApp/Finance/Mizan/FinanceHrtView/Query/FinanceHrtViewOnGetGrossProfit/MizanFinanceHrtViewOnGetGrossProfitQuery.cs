using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetGrossProfit;
public class MizanFinanceHrtViewOnGetGrossProfitQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtViewOnGetGrossProfitResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtViewOnGetGrossProfitRequest Request { get; set; }
}
