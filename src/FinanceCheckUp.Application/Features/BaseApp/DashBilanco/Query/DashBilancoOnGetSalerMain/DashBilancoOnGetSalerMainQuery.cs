using FinanceCheckUp.Application.Models.Requests.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetSalerMain;
public class DashBilancoOnGetSalerMainQuery : IRequest<GenericResult<DashBilancoOnGetSalerMainResponse>>
{

    public DashBilancoOnGetSalerMainRequest RequestModel { get; set; }

}