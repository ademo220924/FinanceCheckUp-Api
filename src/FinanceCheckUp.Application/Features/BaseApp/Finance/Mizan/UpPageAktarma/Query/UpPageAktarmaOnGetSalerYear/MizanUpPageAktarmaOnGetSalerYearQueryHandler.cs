using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetSalerYear
{
    public class MizanUpPageAktarmaOnGetSalerYearQueryHandler : IRequestHandler<MizanUpPageAktarmaOnGetSalerYearQuery, GenericResult<MizanUpPageAktarmaOnGetSalerYearResponse>>
    {
        public Task<GenericResult<MizanUpPageAktarmaOnGetSalerYearResponse>> Handle(MizanUpPageAktarmaOnGetSalerYearQuery request, CancellationToken cancellationToken)
        {
            var yearSetMonth = YearResult.getValue().OrderByDescending(x => x.MYear);
            return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetSalerYearResponse>.Success(new MizanUpPageAktarmaOnGetSalerYearResponse
            {
                Response =new JsonResult(DataSourceLoader.Load(yearSetMonth, request.Request.options))
            }));
        }
    }
}
