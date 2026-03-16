using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpCrmConsole.Query.FinanceUpCrmConsoleOnGetSalerDate;
public class FinanceUpCrmConsoleOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpCrmConsoleOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpCrmConsoleOnGetSalerDateRequest Request { get; set; }
    public FinanceUpCrmConsoleRequestInitialModel InitialModel { get; set; }
}
