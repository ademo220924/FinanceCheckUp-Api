using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGetChartRasyo;
public class MizanFinanceHrtNeoOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanFinanceHrtNeoOnGetChartRasyoQuery, GenericResult<MizanFinanceHrtNeoOnGetChartRasyoResponse>>
{
    public Task<GenericResult<MizanFinanceHrtNeoOnGetChartRasyoResponse>> Handle(MizanFinanceHrtNeoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
          
        return Task.FromResult(GenericResult<MizanFinanceHrtNeoOnGetChartRasyoResponse>.Success(
            new MizanFinanceHrtNeoOnGetChartRasyoResponse
            {
                Response =new JsonResult(DataSourceLoader.Load(request.InitialModel.nRequestList, request.Request.options)),
                InitialModel = request.InitialModel
            }));

    }
}
