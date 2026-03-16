using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetChartRasyo
{
    public class FinanceDashRasyoOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRasyoOnGetChartRasyoResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public FinanceDashRasyoOnGetChartRasyoRequest Request { get; set; }
        public FinanceDashRasyoRequestInitialModel InitialModel { get; set; }
    }
}
