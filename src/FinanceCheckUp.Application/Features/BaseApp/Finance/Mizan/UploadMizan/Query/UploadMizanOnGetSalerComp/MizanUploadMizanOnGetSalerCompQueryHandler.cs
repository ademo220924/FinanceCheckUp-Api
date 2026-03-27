using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGetSalerComp
{
    public class MizanUploadMizanOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadMizanOnGetSalerCompQuery, GenericResult<MizanUploadMizanOnGetSalerCompResponse>>
    {
       
        public Task<GenericResult<MizanUploadMizanOnGetSalerCompResponse>> Handle(MizanUploadMizanOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = (int)userId;
            request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
            
                        return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerCompResponse>.Success(new MizanUploadMizanOnGetSalerCompResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)
            }));
        }
    }
}
