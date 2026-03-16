using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upbalancemzn;
using FinanceCheckUp.Application.Models.Responses.upbalancemzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancemzn.Query.upbalancemznOnGet;
public class upbalancemznOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<upbalancemznOnGetQuery, GenericResult<upbalancemznOnGetResponse>>
{

    public async Task<GenericResult<upbalancemznOnGetResponse>> Handle(upbalancemznOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var responseModel = new upbalancemznRequest
        {
            UserID = UserID
        };

        responseModel.mreqListCompany = companyManager.Getby_User(UserID);
        responseModel.CCompany = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
        responseModel.CompID = responseModel.CCompany.Id;
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilancoMzn(request.Request.nyear, responseModel.CompID);
        responseModel.header = responseModel.CCompany.CompanyName + " " + request.Request.nyear.ToString() + " Yılı Smm Karşılaştırmalı Mizan Raporu";
        return GenericResult<upbalancemznOnGetResponse>.Success(new upbalancemznOnGetResponse { InitialModel = responseModel });
    }
}