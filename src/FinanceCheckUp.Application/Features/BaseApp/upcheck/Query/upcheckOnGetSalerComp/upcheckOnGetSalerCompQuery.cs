using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upcheck;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetSalerComp;
public class upcheckOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<upcheckOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcheckOnGetSalerCompRequest Request { get; set; }

}