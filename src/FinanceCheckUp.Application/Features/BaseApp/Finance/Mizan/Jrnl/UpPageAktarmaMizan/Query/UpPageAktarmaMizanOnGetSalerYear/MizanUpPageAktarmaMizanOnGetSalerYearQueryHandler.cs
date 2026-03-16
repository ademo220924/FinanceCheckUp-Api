using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGetSalerYear;

public class MizanUpPageAktarmaMizanOnGetSalerYearQueryHandler : IRequestHandler<MizanUpPageAktarmaMizanOnGetSalerYearQuery, GenericResult<MizanUpPageAktarmaMizanOnGetSalerYearResponse>>
{
 

    public Task<GenericResult<MizanUpPageAktarmaMizanOnGetSalerYearResponse>> Handle(MizanUpPageAktarmaMizanOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
        return Task.FromResult(GenericResult<MizanUpPageAktarmaMizanOnGetSalerYearResponse>.Success(
            new MizanUpPageAktarmaMizanOnGetSalerYearResponse
            { 
                 
                Response = new JsonResult(DataSourceLoader.Load(yearSetm, request.Request.options))
            }));
  
    }
}



