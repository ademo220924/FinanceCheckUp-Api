using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadSmm.Query.UploadSmmOnGetSalerYear
{
    public class MizanUploadSmmOnGetSalerYearQueryHandler : IRequestHandler<MizanUploadSmmOnGetSalerYearQuery, GenericResult<MizanUploadSmmOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUploadSmmOnGetSalerYearResponse>> Handle(MizanUploadSmmOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
            return Task.FromResult(GenericResult<MizanUploadSmmOnGetSalerYearResponse>.Success(new MizanUploadSmmOnGetSalerYearResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
            }));
        }
    }
}
