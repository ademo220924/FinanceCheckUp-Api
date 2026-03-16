using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGetSalerComp
{
    public class MizanUpBalanceOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUpBalanceOnGetSalerCompQuery, GenericResult<MizanUpBalanceOnGetSalerCompResponse>>
    {

        public Task<GenericResult<MizanUpBalanceOnGetSalerCompResponse>> Handle(MizanUpBalanceOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var mreqListCompany = companyManager.Getby_User(userId);
    
            return Task.FromResult(GenericResult<MizanUpBalanceOnGetSalerCompResponse>.Success(new MizanUpBalanceOnGetSalerCompResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.options))
            }));
        }
    }
}
