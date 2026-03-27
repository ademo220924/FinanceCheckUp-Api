using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetSalerComp;
public class upbalanceOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upbalanceOnGetSalerCompQuery, GenericResult<upbalanceOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upbalanceOnGetSalerCompResponse>> Handle(upbalanceOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upbalanceOnGetSalerCompResponse>.Success(new upbalanceOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}