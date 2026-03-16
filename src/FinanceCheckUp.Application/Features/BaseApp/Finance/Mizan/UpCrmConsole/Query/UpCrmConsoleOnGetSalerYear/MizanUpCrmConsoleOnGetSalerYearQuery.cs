using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpCrmConsole.Query.UpCrmConsoleOnGetSalerYear;
public class MizanUpCrmConsoleOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpCrmConsoleOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanUpCrmConsoleOnGetSalerYearRequest Request { get; set; }
}
