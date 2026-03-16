using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoAkt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoAkt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoAkt.Query.DashBilancoAktOnGet
{
    public class MizanDashBilancoAktOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoAktOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoAktOnGetRequest Request { get; set; }
    }
}
