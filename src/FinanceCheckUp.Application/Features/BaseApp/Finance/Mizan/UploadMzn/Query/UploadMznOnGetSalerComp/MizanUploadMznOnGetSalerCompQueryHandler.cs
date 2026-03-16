using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzn.Query.UploadMznOnGetSalerComp
{
    public class MizanUploadMznOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadMznOnGetSalerCompQuery, GenericResult<MizanUploadMznOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUploadMznOnGetSalerCompResponse>> Handle(MizanUploadMznOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            return Task.FromResult(GenericResult<MizanUploadMznOnGetSalerCompResponse>.Success(new MizanUploadMznOnGetSalerCompResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options))
            }));
        }
    }
}
