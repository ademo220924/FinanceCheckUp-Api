using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upreportqnb;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerYear;
public class upreportqnbOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<upreportqnbOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upreportqnbOnGetSalerYearRequest Request { get; set; }

}