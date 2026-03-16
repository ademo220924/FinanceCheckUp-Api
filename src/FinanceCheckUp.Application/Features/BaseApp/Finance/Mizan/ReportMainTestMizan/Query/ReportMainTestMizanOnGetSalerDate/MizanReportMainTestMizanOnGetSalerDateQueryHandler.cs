using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGetSalerDate;
public class MizanReportMainTestMizanOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager) : IRequestHandler<MizanReportMainTestMizanOnGetSalerDateQuery, GenericResult<MizanReportMainTestMizanOnGetSalerDateResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetSalerDateResponse>> Handle(MizanReportMainTestMizanOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyMain(request.InitialModel.curcomID);

        return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetSalerDateResponse>.Success(new MizanReportMainTestMizanOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options))
        }));
       
    }
}
