using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtView;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGet;
public class FinanceFinanceHrtViewOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtViewOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtViewOnGetRequest Request { get; set; }
}
