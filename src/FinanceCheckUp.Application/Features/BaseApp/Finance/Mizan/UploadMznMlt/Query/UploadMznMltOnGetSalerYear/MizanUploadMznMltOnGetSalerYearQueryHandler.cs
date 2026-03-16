using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerYear
{
    public class MizanUploadMznMltOnGetSalerYearQueryHandler : IRequestHandler<MizanUploadMznMltOnGetSalerYearQuery, GenericResult<MizanUploadMznMltOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUploadMznMltOnGetSalerYearResponse>> Handle(MizanUploadMznMltOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
            return Task.FromResult(GenericResult<MizanUploadMznMltOnGetSalerYearResponse>.Success(new MizanUploadMznMltOnGetSalerYearResponse
            {
                Response =new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
            }));
        }
    }
}
