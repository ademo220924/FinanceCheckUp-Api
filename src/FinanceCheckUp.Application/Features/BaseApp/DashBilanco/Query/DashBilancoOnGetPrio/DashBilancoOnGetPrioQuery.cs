using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetPrio;
public class DashBilancoOnGetPrioQuery : IRequest<GenericResult<DashBilancoOnGetPrioResponse>>
{

    public DashBilancoOnGetPrioRequest RequestModel { get; set; }

}