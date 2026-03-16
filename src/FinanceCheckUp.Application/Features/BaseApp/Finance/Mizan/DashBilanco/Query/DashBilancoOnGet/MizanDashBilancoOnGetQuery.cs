using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilanco.Query.DashBilancoOnGet
{
    public class MizanDashBilancoOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoOnGetRequest Request { get; set; }
    }
}
