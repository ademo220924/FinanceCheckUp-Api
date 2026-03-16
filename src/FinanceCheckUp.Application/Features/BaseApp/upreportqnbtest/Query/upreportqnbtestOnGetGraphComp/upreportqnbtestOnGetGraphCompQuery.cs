using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upreportqnbtest;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetGraphComp;
public class upreportqnbtestOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<upreportqnbtestOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upreportqnbtestOnGetGraphCompRequest Request { get; set; }

}