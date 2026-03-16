using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGet;
public class upreportmainyOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upreportmainyOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}