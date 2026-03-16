using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.reportpot;
using FinanceCheckUp.Application.Models.Responses.reportpot;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.reportpot.Query.reportpotOnGet;
public class reportpotOnGetQuery : IUserIdAssignable , IRequest<GenericResult<reportpotOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public reportpotOnGetRequest Request { get; set; }

}