using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalanceAkt;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalanceAkt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalanceAkt.Query.FinanceUpBalanceAktOnGet;
public class FinanceUpBalanceAktOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpBalanceAktOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpBalanceAktOnGetRequest Request { get; set; }
}
