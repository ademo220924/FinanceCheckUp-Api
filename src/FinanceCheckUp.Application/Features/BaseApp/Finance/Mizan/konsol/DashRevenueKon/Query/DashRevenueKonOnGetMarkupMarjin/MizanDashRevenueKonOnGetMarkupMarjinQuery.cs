using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGetMarkupMarjin
{
    public class MizanDashRevenueKonOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashRevenueKonOnGetMarkupMarjinResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashRevenueKonOnGetMarkupMarjinRequest Request { get; set; }
    }
}
