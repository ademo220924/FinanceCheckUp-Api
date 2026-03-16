using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.CashFlow;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetMarkupMarjin
{
    public class GetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<GetMarkupMarjinResponseModel>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public GetMarkupMarjinRequestModel RequestModel { get; set; }
    }
}