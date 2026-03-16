using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashWorkingCapital.Query.DashWorkingCapitalOnGet;
public class MizanDashWorkingCapitalOnGetQueryHandler(IDashWCapitalMizanManager dashWCapitalMizanManager,IReportDashMizanManager reportDashMizanManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashWorkingCapitalOnGetQuery, GenericResult<MizanDashWorkingCapitalOnGetResponse>>
{
    
    public Task<GenericResult<MizanDashWorkingCapitalOnGetResponse>> Handle(MizanDashWorkingCapitalOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashWorkingCapitalRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };

        
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        responseModel.nRequestListViewChart = reportDashMizanManager.Get_Data_WorkingCapital(responseModel.CompID);
        responseModel.nRequestList = dashWCapitalMizanManager.Get_getDataWcapFINALMain(responseModel.CompID);
        
        
        return Task.FromResult(GenericResult<MizanDashWorkingCapitalOnGetResponse>.Success(
            new MizanDashWorkingCapitalOnGetResponse
            { 
                InitialModel= responseModel
            }));
    }
}