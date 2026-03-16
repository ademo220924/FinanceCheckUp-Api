using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upreportqnbtest;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetGetRep;
public class upreportqnbtestOnGetGetRepQuery : IUserIdAssignable , IRequest<GenericResult<upreportqnbtestOnGetGetRepResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upreportqnbtestOnGetGetRepRequest Request { get; set; }

}