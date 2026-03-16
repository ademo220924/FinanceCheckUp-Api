using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGetSalerComp
{
    public class MizanUploadMznOldYedekOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadMznOldYedekOnGetSalerCompQuery, GenericResult<MizanUploadMznOldYedekOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUploadMznOldYedekOnGetSalerCompResponse>> Handle(MizanUploadMznOldYedekOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            return Task.FromResult(GenericResult<MizanUploadMznOldYedekOnGetSalerCompResponse>.Success(new MizanUploadMznOldYedekOnGetSalerCompResponse
            {
                Response =new JsonResult(DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options))
            }));
        }
    }
}
