using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGetMarkupMarjinB;
public class MizanFinanceHrtFibaOnGetMarkupMarjinBQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinBResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtFibaOnGetMarkupMarjinBRequest Request { get; set; }
}
