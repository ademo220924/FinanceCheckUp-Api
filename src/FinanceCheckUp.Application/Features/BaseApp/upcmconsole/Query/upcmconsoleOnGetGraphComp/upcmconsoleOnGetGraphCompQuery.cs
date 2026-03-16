using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetGraphComp;
public class upcmconsoleOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<upcmconsoleOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcmconsoleOnGetGraphCompRequest Request { get; set; }

}