using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpCrmConsole.Query.FinanceUpCrmConsoleOnGetSalerYear;
public class FinanceUpCrmConsoleOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpCrmConsoleOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpCrmConsoleOnGetSalerYearRequest Request { get; set; }
}
