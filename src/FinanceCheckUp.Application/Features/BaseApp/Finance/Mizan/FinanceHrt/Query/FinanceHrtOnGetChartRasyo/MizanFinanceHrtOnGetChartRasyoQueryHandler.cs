using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrt.Query.FinanceHrtOnGetChartRasyo;
public class MizanFinanceHrtOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager,   ICompanyManager companyManager) : IRequestHandler<MizanFinanceHrtOnGetChartRasyoQuery, GenericResult<MizanFinanceHrtOnGetChartRasyoResponse>>
{
 

    public Task<GenericResult<MizanFinanceHrtOnGetChartRasyoResponse>> Handle(MizanFinanceHrtOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(userId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
         
        return Task.FromResult(GenericResult<MizanFinanceHrtOnGetChartRasyoResponse>.Success(
            new MizanFinanceHrtOnGetChartRasyoResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.nRequestList, request.Request.options)),
                InitialModel = request.InitialModel
            }));
    }
}
