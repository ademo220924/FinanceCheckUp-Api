using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerDate;
public class upaccountOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<upaccountOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upaccountOnGetSalerDateRequest Request { get; set; }

}