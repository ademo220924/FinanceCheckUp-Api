using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetGraphComp;
public class DashBilancoOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashBilancoOnGetGraphCompResponse>>
{

    public DashBilancoOnGetGraphCompRequest RequestModel { get; set; }

    [JsonIgnore] public  string UserId { get; set; }
}