using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpCrmConsole.Query.FinanceUpCrmConsoleOnGet;
public class FinanceUpCrmConsoleOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpCrmConsoleOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpCrmConsoleOnGetRequest Request { get; set; }
}
