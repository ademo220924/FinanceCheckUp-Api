using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGet;

public class MizanFinanceHrtOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtOnGetRequest Request { get; set; }
}
