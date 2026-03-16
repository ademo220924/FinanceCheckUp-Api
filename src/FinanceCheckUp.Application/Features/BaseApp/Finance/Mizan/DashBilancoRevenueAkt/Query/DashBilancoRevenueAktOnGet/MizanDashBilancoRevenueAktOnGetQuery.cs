using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoRevenueAkt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueAkt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueAkt.Query.DashBilancoRevenueAktOnGet
{
    public class MizanDashBilancoRevenueAktOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoRevenueAktOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoRevenueAktOnGetRequest Request { get; set; }
    }
}
