using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerDate;
public class MizanReportMainTestMizanOldOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) 
    : IRequestHandler<MizanReportMainTestMizanOldOnGetSalerDateQuery, GenericResult<MizanReportMainTestMizanOldOnGetSalerDateResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOldOnGetSalerDateResponse>> Handle(MizanReportMainTestMizanOldOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyMain(request.InitialModel.curcomID);
        
                return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetSalerDateResponse>.Success(new MizanReportMainTestMizanOldOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response= DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        }));
    }
}
