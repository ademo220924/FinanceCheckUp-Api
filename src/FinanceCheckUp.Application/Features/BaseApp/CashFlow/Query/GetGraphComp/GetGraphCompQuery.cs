using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.CashFlow;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetGraphComp
{
    public class GetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<GetGraphCompResponseModel>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public GetGraphCompRequestModel RequestModel { get; set; }

    }
}
