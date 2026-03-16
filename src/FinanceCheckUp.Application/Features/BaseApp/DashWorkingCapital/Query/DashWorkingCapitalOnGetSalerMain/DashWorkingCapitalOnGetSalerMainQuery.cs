using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetSalerMain;
public class DashWorkingCapitalOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<DashWorkingCapitalOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashWorkingCapitalOnGetSalerMainRequest Request { get; set; }

}