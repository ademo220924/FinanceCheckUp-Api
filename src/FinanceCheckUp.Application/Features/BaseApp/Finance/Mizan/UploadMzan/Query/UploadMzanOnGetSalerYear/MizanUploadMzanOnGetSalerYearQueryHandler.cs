using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGetSalerYear
{
    public class MizanUploadMzanOnGetSalerYearQueryHandler : IRequestHandler<MizanUploadMzanOnGetSalerYearQuery, GenericResult<MizanUploadMzanOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUploadMzanOnGetSalerYearResponse>> Handle(MizanUploadMzanOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
                        return Task.FromResult(GenericResult<MizanUploadMzanOnGetSalerYearResponse>.Success(new MizanUploadMzanOnGetSalerYearResponse
            {
                Response = DataSourceLoader.Load(yearSetMonth, request.Request.options)
            }));
        }
    }
}
