using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenueJrnl.Query.DashRevenueJrnlOnGetMarkupMarjin;
public class FinanceDashRevenueJrnlOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRevenueJrnlOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashRevenueJrnlOnGetMarkupMarjinRequest Request { get; set; }
    public FinanceDashRevenueJrnlRequestInitialModel InitialModel { get; set; }
}
