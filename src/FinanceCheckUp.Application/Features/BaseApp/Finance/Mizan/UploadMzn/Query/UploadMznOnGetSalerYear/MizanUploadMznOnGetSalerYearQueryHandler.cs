using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzn.Query.UploadMznOnGetSalerYear
{
    public class MizanUploadMznOnGetSalerYearQueryHandler : IRequestHandler<MizanUploadMznOnGetSalerYearQuery, GenericResult<MizanUploadMznOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUploadMznOnGetSalerYearResponse>> Handle(MizanUploadMznOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
            return Task.FromResult(GenericResult<MizanUploadMznOnGetSalerYearResponse>.Success(new MizanUploadMznOnGetSalerYearResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
            }));
        }
    }
}
