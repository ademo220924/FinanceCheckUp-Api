using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetSalerMain;
public class DashBilancoOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashBilancoOnGetSalerMainQuery, GenericResult<DashBilancoOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashBilancoOnGetSalerMainResponse>> Handle(DashBilancoOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var dt1 = "105";
        var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
                return GenericResult<DashBilancoOnGetSalerMainResponse>.Success(new DashBilancoOnGetSalerMainResponse { Result = DataSourceLoader.Load(winModelTlist, request.RequestModel.DataSourceLoadOptions) });
    }
}