using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalanceAkt;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalanceAkt;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalanceAkt.Query.FinanceUpBalanceAktOnGet;
public class FinanceUpBalanceAktOnGetQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) 
    : IRequestHandler<FinanceUpBalanceAktOnGetQuery, GenericResult<FinanceUpBalanceAktOnGetResponse>>
{

    public Task<GenericResult<FinanceUpBalanceAktOnGetResponse>> Handle(FinanceUpBalanceAktOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new FinanceUpBalanceAktRequestInitialModel
        {  
            UserID = (int)userId
        };

        responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        responseModel.CCompanies = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault(); 
        responseModel.CompID = responseModel.CCompanies.Id;
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilancoAkt(request.Request.nyear, responseModel.CompID); 
        responseModel.header = responseModel.CCompanies.CompanyName + " " + request.Request.nyear.ToString() + " Yılı Aktarma Karşılaştırmalı Mizan Raporu";
 
        return Task.FromResult(GenericResult<FinanceUpBalanceAktOnGetResponse>.Success(new FinanceUpBalanceAktOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}
