using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashBilancoKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGetMarkupMarjin
{
    public class MizanDashBilancoKonOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoKonOnGetMarkupMarjinResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoKonOnGetMarkupMarjinRequest Request { get; set; }
    }
}
