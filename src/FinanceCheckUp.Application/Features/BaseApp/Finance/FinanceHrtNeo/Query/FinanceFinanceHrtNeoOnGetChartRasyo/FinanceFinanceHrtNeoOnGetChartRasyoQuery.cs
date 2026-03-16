using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtNeo;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGetChartRasyo;
public class FinanceFinanceHrtNeoOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtNeoOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtNeoOnGetChartRasyoRequest Request { get; set; }
    public FinanceFinanceHrtNeoRequestInitialModel InitialModel { get; set; }
}
