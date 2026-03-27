using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetSalerComp;
public class UpreportqnbtestOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upreportqnbtestOnGetSalerCompQuery, GenericResult<upreportqnbtestOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upreportqnbtestOnGetSalerCompResponse>> Handle(upreportqnbtestOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<upreportqnbtestOnGetSalerCompResponse>.Success(new upreportqnbtestOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}