using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrt.Query.FinanceFinanceHrtOnGetChartRasyo;
public class FinanceFinanceHrtOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtOnGetChartRasyoRequest Request { get; set; }
    public FinanceFinanceHrtRequestInitialModel InitialModel { get; set; }
}
