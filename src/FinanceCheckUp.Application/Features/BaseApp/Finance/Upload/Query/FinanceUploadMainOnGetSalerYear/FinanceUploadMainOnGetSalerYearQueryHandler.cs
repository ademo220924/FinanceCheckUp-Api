using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerYear;

public class FinanceUploadMainOnGetSalerYearQueryHandler
    : IRequestHandler<FinanceUploadMainOnGetSalerYearQuery, GenericResult<FinanceUploadMainOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUploadMainOnGetSalerYearResponse>> Handle(FinanceUploadMainOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
        return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerYearResponse>.Success(
            new FinanceUploadMainOnGetSalerYearResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
            }));
    }
}