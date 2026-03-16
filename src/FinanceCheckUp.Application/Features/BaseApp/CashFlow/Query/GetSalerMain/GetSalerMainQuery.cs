using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.CashFlow;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetSalerMain;
public class GetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<GetSalerMainResponseModel>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public GetSalerMainRequestModel RequestModel { get; set; }
}