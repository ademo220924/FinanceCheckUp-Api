using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGetSalerYear
{
    public class MizanUploadMainOnGetSalerYearQueryHandler
        : IRequestHandler<MizanUploadMainOnGetSalerYearQuery, GenericResult<MizanUploadMainOnGetSalerYearResponse>>
    {

        public Task<GenericResult<MizanUploadMainOnGetSalerYearResponse>> Handle(MizanUploadMainOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
            
            return Task.FromResult(GenericResult<MizanUploadMainOnGetSalerYearResponse>.Success(
                new MizanUploadMainOnGetSalerYearResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
                }));
        }
    }
}