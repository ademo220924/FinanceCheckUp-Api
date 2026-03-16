using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerYear;
public class upcmconsoleOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<upcmconsoleOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upcmconsoleOnGetSalerYearRequest Request { get; set; }

}