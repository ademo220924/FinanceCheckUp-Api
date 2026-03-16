using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.CashFlow;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetPrio
{
    public class GetPrioQuery : IUserIdAssignable , IRequest<GenericResult<GetPrioResponseModel>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public GetPrioRequestModel RequestModel { get; set; }
    }
}
