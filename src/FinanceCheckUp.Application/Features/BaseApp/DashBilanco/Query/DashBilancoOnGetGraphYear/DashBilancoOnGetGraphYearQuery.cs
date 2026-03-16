using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;



namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetGraphYear;
public class DashBilancoOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashBilancoOnGetGraphYearResponse>>
{

    public DashBilancoOnGetGraphYearRequest RequestModel { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}