using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGetSalerComp;
public class UpreportmainyOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upreportmainyOnGetSalerCompQuery, GenericResult<upreportmainyOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upreportmainyOnGetSalerCompResponse>> Handle(upreportmainyOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upreportmainyOnGetSalerCompResponse>.Success(new upreportmainyOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}