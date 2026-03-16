using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoRevenueMlt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGetChartRasyo
{
    public class MizanDashBilancoRevenueMltOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoRevenueMltOnGetChartRasyoResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoRevenueMltOnGetChartRasyoRequest Request { get; set; }
        public MizanDashBilancoRevenueMltRequestInitialModel InitialModel { get; set; }
    }
}
