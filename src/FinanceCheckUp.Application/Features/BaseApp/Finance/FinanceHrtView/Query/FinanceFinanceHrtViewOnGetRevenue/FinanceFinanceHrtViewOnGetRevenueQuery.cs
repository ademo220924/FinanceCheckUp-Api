using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetRevenue;
public class FinanceFinanceHrtViewOnGetRevenueQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtViewOnGetRevenueResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtViewOnGetRevenueRequest Request { get; set; }
    public FinanceFinanceHrtViewRequestInitialModel InitialModel { get; set; }
}
