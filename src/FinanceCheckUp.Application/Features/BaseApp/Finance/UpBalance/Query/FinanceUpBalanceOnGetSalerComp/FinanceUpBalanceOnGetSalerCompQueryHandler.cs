using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerComp;
public class FinanceUpBalanceOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<FinanceUpBalanceOnGetSalerCompQuery, GenericResult<FinanceUpBalanceOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceUpBalanceOnGetSalerCompResponse>> Handle(FinanceUpBalanceOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var mreqListCompany = companyManager.Getby_User(userId);
        
        return Task.FromResult(GenericResult<FinanceUpBalanceOnGetSalerCompResponse>.Success(new FinanceUpBalanceOnGetSalerCompResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.options))
        }));
    }
}
