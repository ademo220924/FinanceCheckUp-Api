using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpCrmConsole.Query.FinanceUpCrmConsoleOnGetSalerDate;
public class FinanceUpCrmConsoleOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) 
    : IRequestHandler<FinanceUpCrmConsoleOnGetSalerDateQuery, GenericResult<FinanceUpCrmConsoleOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceUpCrmConsoleOnGetSalerDateResponse>> Handle(FinanceUpCrmConsoleOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyConsole( request.InitialModel.curcomID);
        
        return Task.FromResult(GenericResult<FinanceUpCrmConsoleOnGetSalerDateResponse>.Success(new FinanceUpCrmConsoleOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options))
        }));
    }
}
