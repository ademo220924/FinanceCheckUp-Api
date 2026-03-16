using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashRevenueKon.Query.DashRevenueKonOnGetMarkupMarjin
{
    public class DashRevenueKonOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueKonOnGetMarkupMarjinResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public DashRevenueKonOnGetMarkupMarjinRequest Request { get; set; }
        public DashRevenueKonInitialModel InitialModel { get; set; }

    }
}
