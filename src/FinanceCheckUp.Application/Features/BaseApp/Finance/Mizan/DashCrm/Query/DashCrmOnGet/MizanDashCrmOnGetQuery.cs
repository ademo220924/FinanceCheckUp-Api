using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm.Query.DashCrmOnGet
{
    public class MizanDashCrmOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashCrmOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashCrmOnGetRequest Request { get; set; }
    }
}
