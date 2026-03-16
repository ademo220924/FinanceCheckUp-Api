using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoMlt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoMlt.Query.DashBilancoMltOnGet
{
    public class MizanDashBilancoMltOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoMltOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoMltOnGetRequest Request { get; set; }
    }
}
