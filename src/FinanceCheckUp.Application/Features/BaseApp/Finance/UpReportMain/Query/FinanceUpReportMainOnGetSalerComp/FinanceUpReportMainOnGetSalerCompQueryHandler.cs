using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpReportMain.Query.FinanceUpReportMainOnGetSalerComp;
public class FinanceUpReportMainOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<FinanceUpReportMainOnGetSalerCompQuery, GenericResult<FinanceUpReportMainOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceUpReportMainOnGetSalerCompResponse>> Handle(FinanceUpReportMainOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
      
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
        
        return Task.FromResult(GenericResult<FinanceUpReportMainOnGetSalerCompResponse>.Success(new FinanceUpReportMainOnGetSalerCompResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options))
        }));

    }
}
