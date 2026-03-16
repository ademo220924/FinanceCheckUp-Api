using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upcheck;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetGraphComp;
public class upcheckOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<upcheckOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcheckOnGetGraphCompRequest Request { get; set; }

}