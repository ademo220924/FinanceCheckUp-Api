using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetSalerYear;
public class UploadOnGetSalerYearQueryHandler : IRequestHandler<UploadOnGetSalerYearQuery, GenericResult<UploadOnGetSalerYearResponse>>
{

    public async Task<GenericResult<UploadOnGetSalerYearResponse>> Handle(UploadOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
                return GenericResult<UploadOnGetSalerYearResponse>.Success(new UploadOnGetSalerYearResponse { Result = DataSourceLoader.Load(YearSetm, request.Request.Options) });
    }
}