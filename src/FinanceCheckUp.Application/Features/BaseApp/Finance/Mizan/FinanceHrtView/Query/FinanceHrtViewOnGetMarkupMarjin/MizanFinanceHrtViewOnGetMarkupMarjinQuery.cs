using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetMarkupMarjin;
public class MizanFinanceHrtViewOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtViewOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtViewOnGetMarkupMarjinRequest Request { get; set; }
}