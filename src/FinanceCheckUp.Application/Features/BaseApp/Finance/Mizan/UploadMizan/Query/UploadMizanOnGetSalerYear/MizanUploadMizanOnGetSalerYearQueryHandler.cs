using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGetSalerYear
{
    public class MizanUploadMizanOnGetSalerYearQueryHandler : IRequestHandler<MizanUploadMizanOnGetSalerYearQuery, GenericResult<MizanUploadMizanOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUploadMizanOnGetSalerYearResponse>> Handle(MizanUploadMizanOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                        return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerYearResponse>.Success(new MizanUploadMizanOnGetSalerYearResponse
            {
                Response =DataSourceLoader.Load(yearSetMonth, request.Request.options)
            }));
        }
    }
}
