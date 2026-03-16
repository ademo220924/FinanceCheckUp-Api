using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGet;
public class DashWorkingCapitalOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashWorkingCapitalOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashWorkingCapitalOnGetRequest Request { get; set; }

}