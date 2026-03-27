using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerComp;
public class upaccountyOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upaccountyOnGetSalerCompQuery, GenericResult<upaccountyOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upaccountyOnGetSalerCompResponse>> Handle(upaccountyOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upaccountyOnGetSalerCompResponse>.Success(new upaccountyOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}