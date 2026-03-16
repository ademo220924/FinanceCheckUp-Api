using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGet
{
    public class MizanDashRevenueKonOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashRevenueKonOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashRevenueKonOnGetRequest Request { get; set; }
    }
}
