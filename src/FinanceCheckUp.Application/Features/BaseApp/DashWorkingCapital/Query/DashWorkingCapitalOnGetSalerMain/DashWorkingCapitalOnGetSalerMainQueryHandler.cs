using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetSalerMain;
public class DashWorkingCapitalOnGetSalerMainQueryHandler(IDataManager dataManager) : IRequestHandler<DashWorkingCapitalOnGetSalerMainQuery, GenericResult<DashWorkingCapitalOnGetSalerMainResponse>>
{

    public async Task<GenericResult<DashWorkingCapitalOnGetSalerMainResponse>> Handle(DashWorkingCapitalOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var winModelTlist = dataManager.Get_AllbyCsvID(request.Request.dt1);
                return GenericResult<DashWorkingCapitalOnGetSalerMainResponse>.Success(new DashWorkingCapitalOnGetSalerMainResponse { Response = DataSourceLoader.Load(winModelTlist, request.Request.Options) });
    }
}