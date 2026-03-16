using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilanco.Query.DashBilancoOnGetChartRasyo
{
    public class MizanDashBilancoOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashBilancoOnGetChartRasyoResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanDashBilancoOnGetChartRasyoRequest Request { get; set; }
        public MizanDashBilancoRequestInitialModel InitialModel { get; set; }
    }
}
