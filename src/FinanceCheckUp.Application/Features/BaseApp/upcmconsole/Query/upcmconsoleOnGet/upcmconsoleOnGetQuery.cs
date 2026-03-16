using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGet;
public class UpcmconsoleOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upcmconsoleOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}