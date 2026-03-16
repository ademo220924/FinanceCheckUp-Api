using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerComp
{
    public class MizanUpBalanceNewOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUpBalanceNewOnGetSalerCompQuery, GenericResult<MizanUpBalanceNewOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUpBalanceNewOnGetSalerCompResponse>> Handle(MizanUpBalanceNewOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetSalerCompResponse>.Success(new MizanUpBalanceNewOnGetSalerCompResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options))
            }));
        }
    }
}
