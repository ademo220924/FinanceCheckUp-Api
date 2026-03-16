using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetMarkupMarjinB;
public class MizanFinanceHrtOnGetMarkupMarjinBQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtOnGetMarkupMarjinBResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtOnGetMarkupMarjinBRequest Request { get; set; }
}
