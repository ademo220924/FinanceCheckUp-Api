using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerComp;
public class upreportqnbOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upreportqnbOnGetSalerCompQuery, GenericResult<upreportqnbOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetSalerCompResponse>> Handle(upreportqnbOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upreportqnbOnGetSalerCompResponse>.Success(new upreportqnbOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}