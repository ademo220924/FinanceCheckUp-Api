using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upbalanceakt;
using FinanceCheckUp.Application.Models.Responses.upbalanceakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalanceakt.Query.upbalanceaktOnGet;
public class upbalanceaktOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<upbalanceaktOnGetQuery, GenericResult<upbalanceaktOnGetResponse>>
{

    public async Task<GenericResult<upbalanceaktOnGetResponse>> Handle(upbalanceaktOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upbalanceaktRequest
        {
            UserID = UserID
        };

        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompID = responseModel.CCompany.Id;
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilancoAkt(request.Request.nyear, responseModel.CompID);
        responseModel.header = responseModel.CCompany.CompanyName + " " + request.Request.nyear.ToString() + " Yılı Aktarma Karşılaştırmalı Mizan Raporu";
        return GenericResult<upbalanceaktOnGetResponse>.Success(new upbalanceaktOnGetResponse { InitialModel = responseModel });
    }
}