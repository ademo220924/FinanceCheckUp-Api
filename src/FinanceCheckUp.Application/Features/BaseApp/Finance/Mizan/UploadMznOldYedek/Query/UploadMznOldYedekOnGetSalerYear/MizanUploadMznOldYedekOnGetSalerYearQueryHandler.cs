using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGetSalerYear
{
    public class MizanUploadMznOldYedekOnGetSalerYearQueryHandler : IRequestHandler<MizanUploadMznOldYedekOnGetSalerYearQuery, GenericResult<MizanUploadMznOldYedekOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUploadMznOldYedekOnGetSalerYearResponse>> Handle(MizanUploadMznOldYedekOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
            return Task.FromResult(GenericResult<MizanUploadMznOldYedekOnGetSalerYearResponse>.Success(new MizanUploadMznOldYedekOnGetSalerYearResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
            }));
        }
    }
}
