using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetSalerComp
{
    public class MizanUpPageAktarmaOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaOnGetSalerCompQuery, GenericResult<MizanUpPageAktarmaOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUpPageAktarmaOnGetSalerCompResponse>> Handle(MizanUpPageAktarmaOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetSalerCompResponse>.Success(new MizanUpPageAktarmaOnGetSalerCompResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options))
            }));
        }
    }
}
