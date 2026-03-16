using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGet;
public class MizanFinanceHrtFibaOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtFibaOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtFibaOnGetRequest Request { get; set; }
}
