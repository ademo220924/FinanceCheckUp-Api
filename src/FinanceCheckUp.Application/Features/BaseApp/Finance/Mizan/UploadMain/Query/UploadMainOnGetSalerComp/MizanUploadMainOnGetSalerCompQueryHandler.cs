using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGetSalerComp
{
    public class MizanUploadMainOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadMainOnGetSalerCompQuery, GenericResult<MizanUploadMainOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUploadMainOnGetSalerCompResponse>> Handle(MizanUploadMainOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var mreqListCompany = companyManager.Getby_User(userId);
            
            return Task.FromResult(GenericResult<MizanUploadMainOnGetSalerCompResponse>.Success(new MizanUploadMainOnGetSalerCompResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.options))
            }));
        }
    }
}
