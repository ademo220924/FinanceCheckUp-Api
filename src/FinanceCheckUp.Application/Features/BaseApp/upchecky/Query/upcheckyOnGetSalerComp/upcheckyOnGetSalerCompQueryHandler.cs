using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetSalerComp;
public class upcheckyOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upcheckyOnGetSalerCompQuery, GenericResult<upcheckyOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upcheckyOnGetSalerCompResponse>> Handle(upcheckyOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upcheckyOnGetSalerCompResponse>.Success(new upcheckyOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}