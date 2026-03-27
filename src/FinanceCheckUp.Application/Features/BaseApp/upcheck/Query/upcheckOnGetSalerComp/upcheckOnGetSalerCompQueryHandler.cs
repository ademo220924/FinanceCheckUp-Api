using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGetSalerComp;
public class upcheckOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upcheckOnGetSalerCompQuery, GenericResult<upcheckOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upcheckOnGetSalerCompResponse>> Handle(upcheckOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upcheckOnGetSalerCompResponse>.Success(new upcheckOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}