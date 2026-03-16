using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerYear;
public class upaccountOnGetSalerYearQueryHandler : IRequestHandler<upaccountOnGetSalerYearQuery, GenericResult<upaccountOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upaccountOnGetSalerYearResponse>> Handle(upaccountOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upaccountOnGetSalerYearResponse>.Success(new upaccountOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}