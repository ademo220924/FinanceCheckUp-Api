using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerYear;
public class upreportqnbOnGetSalerYearQueryHandler : IRequestHandler<upreportqnbOnGetSalerYearQuery, GenericResult<upreportqnbOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetSalerYearResponse>> Handle(upreportqnbOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upreportqnbOnGetSalerYearResponse>.Success(new upreportqnbOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}