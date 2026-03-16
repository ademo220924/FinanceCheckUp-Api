using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGetSalerYear;
public class FinanceUpPageAktarmaMznOnGetSalerYearQueryHandler : IRequestHandler<FinanceUpPageAktarmaMznOnGetSalerYearQuery, GenericResult<FinanceUpPageAktarmaMznOnGetSalerYearResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaMznOnGetSalerYearResponse>> Handle(FinanceUpPageAktarmaMznOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
        return Task.FromResult(GenericResult<FinanceUpPageAktarmaMznOnGetSalerYearResponse>.Success(new FinanceUpPageAktarmaMznOnGetSalerYearResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
        }));
    }
}
