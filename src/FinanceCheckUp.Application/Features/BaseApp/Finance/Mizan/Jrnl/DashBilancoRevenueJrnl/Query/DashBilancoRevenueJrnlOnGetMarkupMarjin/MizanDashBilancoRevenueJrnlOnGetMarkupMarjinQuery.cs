using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl.Query.DashBilancoRevenueJrnlOnGetMarkupMarjin;
public class MizanDashBilancoRevenueJrnlOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashBilancoRevenueJrnlOnGetMarkupMarjinRequest Request { get; set; }
    public MizanDashBilancoRevenueJrnlRequestInitialModel InitialModel { get; set; }
}
