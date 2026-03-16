using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashRevenueKon.Query.DashRevenueKonOnGetGraphYear
{
    public class DashRevenueKonOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueKonOnGetGraphYearResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public DashRevenueKonOnGetGraphYearRequest Request { get; set; }
    }
}
