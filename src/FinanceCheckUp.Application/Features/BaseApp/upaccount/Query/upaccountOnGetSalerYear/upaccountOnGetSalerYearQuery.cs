using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerYear;
public class upaccountOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<upaccountOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upaccountOnGetSalerYearRequest Request { get; set; }

}