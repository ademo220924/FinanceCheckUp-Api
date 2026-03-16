using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerComp;
public class FinanceUploadMainOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<FinanceUploadMainOnGetSalerCompQuery, GenericResult<FinanceUploadMainOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceUploadMainOnGetSalerCompResponse>> Handle(FinanceUploadMainOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;


        
        request.InitialModel.mreqListCompany = companyManager.Getby_User(userId);
        
        return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerCompResponse>.Success(new FinanceUploadMainOnGetSalerCompResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)),
            InitialModel = request.InitialModel
        }));

    }
}
