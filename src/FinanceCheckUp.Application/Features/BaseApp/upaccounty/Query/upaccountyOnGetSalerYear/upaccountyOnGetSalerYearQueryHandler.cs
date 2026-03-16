using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerYear;
public class upaccountyOnGetSalerYearQueryHandler : IRequestHandler<upaccountyOnGetSalerYearQuery, GenericResult<upaccountyOnGetSalerYearResponse>>
{

    public async Task<GenericResult<upaccountyOnGetSalerYearResponse>> Handle(upaccountyOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var YearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return GenericResult<upaccountyOnGetSalerYearResponse>.Success(new upaccountyOnGetSalerYearResponse { Result = new JsonResult(DataSourceLoader.Load(YearSetm, request.Request.Options)) });
    }
}