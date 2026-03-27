using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGetSalerComp
{
    public class MizanUploadMzanOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadMzanOnGetSalerCompQuery, GenericResult<MizanUploadMzanOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUploadMzanOnGetSalerCompResponse>> Handle(MizanUploadMzanOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var mreqListCompany = companyManager.Getby_User(userId);
                        return Task.FromResult(GenericResult<MizanUploadMzanOnGetSalerCompResponse>.Success(new MizanUploadMzanOnGetSalerCompResponse
            {
                Response =DataSourceLoader.Load(mreqListCompany, request.Request.options)
            }));
        }
    }
}
