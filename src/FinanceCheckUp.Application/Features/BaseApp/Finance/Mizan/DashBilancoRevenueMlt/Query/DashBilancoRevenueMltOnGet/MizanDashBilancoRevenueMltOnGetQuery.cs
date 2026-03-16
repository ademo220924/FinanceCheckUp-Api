using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoRevenueMlt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGet
{
    public class MizanDashBilancoRevenueMltOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoRevenueMltOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoRevenueMltOnGetRequest Request { get; set; }
    }
}
