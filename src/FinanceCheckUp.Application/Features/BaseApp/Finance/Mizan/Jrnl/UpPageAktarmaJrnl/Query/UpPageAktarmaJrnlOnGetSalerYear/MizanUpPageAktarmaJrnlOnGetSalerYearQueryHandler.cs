using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerYear;
public class MizanUpPageAktarmaJrnlOnGetSalerYearQueryHandler : IRequestHandler<MizanUpPageAktarmaJrnlOnGetSalerYearQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetSalerYearResponse>>
{ 
    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetSalerYearResponse>> Handle(MizanUpPageAktarmaJrnlOnGetSalerYearQuery request, CancellationToken cancellationToken)
    {
        var yearSetm = YearResult.getValue().OrderByDescending(x => x.MYear);
         
        return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetSalerYearResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetSalerYearResponse
            { 
                Response = new JsonResult(DataSourceLoader.Load(yearSetm, request.Request.options))
            }));
    }
}
