using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetChartRasyo;
public class MizanFinancesHrtfibaprOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager) : IRequestHandler<MizanFinancesHrtfibaprOnGetChartRasyoQuery, GenericResult<MizanFinancesHrtfibaprOnGetChartRasyoResponse>>
{
   

    public Task<GenericResult<MizanFinancesHrtfibaprOnGetChartRasyoResponse>> Handle(MizanFinancesHrtfibaprOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);

        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();


                return Task.FromResult(GenericResult<MizanFinancesHrtfibaprOnGetChartRasyoResponse>.Success(
            new MizanFinancesHrtfibaprOnGetChartRasyoResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(request.InitialModel.nRequestList,
                    request.Request.options)
            }));
    }
}
