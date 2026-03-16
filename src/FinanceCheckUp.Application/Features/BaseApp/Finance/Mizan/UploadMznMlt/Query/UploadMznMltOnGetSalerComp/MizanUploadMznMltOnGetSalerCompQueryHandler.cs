using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerComp
{
    public class MizanUploadMznMltOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadMznMltOnGetSalerCompQuery, GenericResult<MizanUploadMznMltOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUploadMznMltOnGetSalerCompResponse>> Handle(MizanUploadMznMltOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId); 
            return Task.FromResult(GenericResult<MizanUploadMznMltOnGetSalerCompResponse>.Success(new MizanUploadMznMltOnGetSalerCompResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options))
            }));
        }
    }
}
