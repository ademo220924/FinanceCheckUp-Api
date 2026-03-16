using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upreportmainy;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGetSalerComp;
public class upreportmainyOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<upreportmainyOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upreportmainyOnGetSalerCompRequest Request { get; set; }

}