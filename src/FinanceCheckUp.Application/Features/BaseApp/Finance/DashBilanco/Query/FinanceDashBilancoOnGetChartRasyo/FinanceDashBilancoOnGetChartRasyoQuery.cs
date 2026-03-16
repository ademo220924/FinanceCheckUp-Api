using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilanco.Query.FinanceDashBilancoOnGetChartRasyo;
public class FinanceDashBilancoOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashBilancoOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashBilancoOnGetChartRasyoRequest Request { get; set; }
    public FinanceDashBilancoRequestInitialModel InitialModel { get; set; }
}
