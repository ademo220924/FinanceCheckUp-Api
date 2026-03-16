using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGetGraphYearDel
{
    public class MizanUploadMizanOnGetGraphYearDelQueryHandler(IDashBilancoSetMizanManager dashBilancoSetMizanManager) 
        : IRequestHandler<MizanUploadMizanOnGetGraphYearDelQuery, GenericResult<MizanUploadMizanOnGetGraphYearDelResponse>>
    {
        public Task<GenericResult<MizanUploadMizanOnGetGraphYearDelResponse>> Handle(MizanUploadMizanOnGetGraphYearDelQuery request, CancellationToken cancellationToken)
        {
            dashBilancoSetMizanManager.Set_ReportSetResetMizanKayit(request.Request.nyear, request.Request.compide);
            return Task.FromResult(GenericResult<MizanUploadMizanOnGetGraphYearDelResponse>.Success(new MizanUploadMizanOnGetGraphYearDelResponse
            {
                Response = new JsonResult("ok")
            })); 
        }
    }
}
