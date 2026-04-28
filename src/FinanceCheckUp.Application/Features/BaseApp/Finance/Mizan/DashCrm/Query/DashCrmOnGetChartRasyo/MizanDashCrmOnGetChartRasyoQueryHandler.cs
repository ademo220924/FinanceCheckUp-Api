using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm.Query.DashCrmOnGetChartRasyo;
public class MizanDashCrmOnGetChartRasyoQueryHandler(IRasyoAnalizMainManager rasyoAnalizMainManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashCrmOnGetChartRasyoQuery, GenericResult<MizanDashCrmOnGetChartRasyoResponse>>
{ 
    public Task<GenericResult<MizanDashCrmOnGetChartRasyoResponse>> Handle(MizanDashCrmOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var yearForCrm = MizanDashCrmCrmDataYearResolver.Resolve(
            request.InitialModel.CurrentUser.SelectedYear,
            tBLXmlManager.GetMaxYearTblXmlSourceOneT(request.InitialModel.CompID));
        request.InitialModel.RasyoAnalizViewCrm = new DashYearlyResultChartCRM();
        request.InitialModel.RasyoAnalizCRM = rasyoAnalizMainManager.CRMAnalizTOTAL102Mizan(yearForCrm, request.InitialModel.CompID);
        request.InitialModel.RasyoAnalizViewCrm.SetResult(request.InitialModel.RasyoAnalizCRM, yearForCrm);

 
        
        return Task.FromResult(GenericResult<MizanDashCrmOnGetChartRasyoResponse>.Success(
            new MizanDashCrmOnGetChartRasyoResponse
            {
                Response = DataSourceLoader.Load(request.InitialModel.RasyoAnalizViewCrm.nresult.OrderByDescending(z => z.Value), request.Request.options),
                InitialModel = request.InitialModel
            }));
    }
}
