using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailc;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetailc.Query.DashCrmDetailcOnGet
{
    public class FinanceDashCrmDetailcOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmDetailcOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public FinanceDashCrmDetailcOnGetRequest Request { get; set; }
        public FinanceDashCrmDetailcRequestInitialModel InitialModel { get; set; }
    }
}
