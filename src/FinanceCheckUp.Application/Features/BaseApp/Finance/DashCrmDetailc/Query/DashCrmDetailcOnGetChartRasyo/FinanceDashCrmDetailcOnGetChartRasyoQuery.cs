using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailc;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetailc.Query.DashCrmDetailcOnGetChartRasyo
{
    public class FinanceDashCrmDetailcOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmDetailcOnGetChartRasyoResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public FinanceDashCrmDetailcOnGetChartRasyoRequest Request { get; set; }
        public FinanceDashCrmDetailcRequestInitialModel InitialModel { get; set; }
    }
}
