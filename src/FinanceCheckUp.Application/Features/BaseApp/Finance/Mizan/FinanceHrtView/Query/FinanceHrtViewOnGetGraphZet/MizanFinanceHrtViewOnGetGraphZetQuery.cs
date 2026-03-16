using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetGraphZet;
public class MizanFinanceHrtViewOnGetGraphZetQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtViewOnGetGraphZetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtViewOnGetGraphZetRequest Request { get; set; }
}
