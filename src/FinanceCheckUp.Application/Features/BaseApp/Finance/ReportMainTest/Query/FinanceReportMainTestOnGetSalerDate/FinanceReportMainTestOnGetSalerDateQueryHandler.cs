using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetSalerDate;
public class FinanceReportMainTestOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager) : IRequestHandler<FinanceReportMainTestOnGetSalerDateQuery, GenericResult<FinanceReportMainTestOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOnGetSalerDateResponse>> Handle(FinanceReportMainTestOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.curcomID = companyManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyMain(request.InitialModel.curcomID);
 
        return Task.FromResult(GenericResult<FinanceReportMainTestOnGetSalerDateResponse>.Success(new FinanceReportMainTestOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options))
        }));
    }
}
