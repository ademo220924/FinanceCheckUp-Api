using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetSalerComp;
public class UploadOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<UploadOnGetSalerCompQuery, GenericResult<UploadOnGetSalerCompResponse>>
{

    public async Task<GenericResult<UploadOnGetSalerCompResponse>> Handle(UploadOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
                return GenericResult<UploadOnGetSalerCompResponse>.Success(new UploadOnGetSalerCompResponse { Result = DataSourceLoader.Load(mreqListCompany, request.Request.Options) });
    }
}