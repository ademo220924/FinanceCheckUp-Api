using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Globalization;
using System.Collections.Generic;
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashLiquidity.Query.DashLiquidityOnGet;
public class MizanDashLiquidityOnGetQueryHandler(IDashLikiditeViewMainMizanManager dashLikiditeViewMainMizanManager,IDashLikiditeMizanManager dashLikiditeMizanManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashLiquidityOnGetQuery, GenericResult<MizanDashLiquidityOnGetResponse>>
{

    public Task<GenericResult<MizanDashLiquidityOnGetResponse>> Handle(MizanDashLiquidityOnGetQuery request, CancellationToken cancellationToken)
    { 
        
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashLiquidityRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
        
        
        
        responseModel.CompID = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        responseModel.CompName = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault().CompanyName;
        hhvnUsersManager.SetYearMain(responseModel.CompID, responseModel.UserID);
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.nRequestListChk = dashLikiditeMizanManager.Get_MAINRESULTMultiMain(responseModel.CompID);




        responseModel.YearCount = tBLXmlManager.GetYearByComapnyID(responseModel.CompID);
        responseModel.CompCount = responseModel.mreqListCompany.Count();
        var chkkkt = dashLikiditeMizanManager.Get_MainList(responseModel.CompID);
        if (chkkkt.Count < 1)
        {
            responseModel.nRequestList = dashLikiditeViewMainMizanManager.getList(responseModel.CurrentUser.SelectedYear, responseModel.CompID);
        }
        else
        {
            responseModel.nRequestList = chkkkt;
        }

        try
        {
            if (responseModel.nRequestListChk is { Count: > 0 })
            {
                var val5 = responseModel.nRequestListChk.Where(x => x.TypeID == 333).FirstOrDefault().Amount;
                if (val5 == 0)
                {
                    val5 = 1;
                }
                decimal chkt = Convert.ToDecimal(responseModel.nRequestListChk.Where(x => (x.TypeID == 111)).FirstOrDefault().Amount - responseModel.nRequestListChk.Where(x => (x.TypeID == 15)).FirstOrDefault().Amount);
                responseModel.NetIsletmeT = chkt / Convert.ToDecimal(val5);
                if (responseModel.NetIsletmeT < 0)
                {
                    responseModel.NetIsletmeT = responseModel.NetIsletmeT * -1;
                }

                responseModel.NetIsletme = responseModel.NetIsletmeT.ToString("F", new CultureInfo("en-US", false));
            }


        }
        catch (Exception)
        {

            responseModel.NetIsletme = (0).ToString("F", new CultureInfo("en-US", false));
        }
 
        responseModel.nRequestChart = dashLikiditeMizanManager.Get_LikiditeORANT(responseModel.CompID)
            ?? new List<DashYearlyResultMizan>();
        
        return Task.FromResult(GenericResult<MizanDashLiquidityOnGetResponse>.Success(
            new MizanDashLiquidityOnGetResponse
            {
                InitialModel = responseModel
            }));
    }
}
