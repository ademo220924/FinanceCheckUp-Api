using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerMainZeta;
public class upaccountOnGetSalerMainZetaQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager) : IRequestHandler<upaccountOnGetSalerMainZetaQuery, GenericResult<upaccountOnGetSalerMainZetaResponse>>
{

    public async Task<GenericResult<upaccountOnGetSalerMainZetaResponse>> Handle(upaccountOnGetSalerMainZetaQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upaccountRequest();

        responseModel.mrequestDataViewer = new DataViewerMain();
        if (request.Request.monthid < 1)
                        return GenericResult<upaccountOnGetSalerMainZetaResponse>.Success(new upaccountOnGetSalerMainZetaResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options) });

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(responseModel.CurrentUser.SelectedYear, responseModel.curcomID, request.Request.monthid));
                return GenericResult<upaccountOnGetSalerMainZetaResponse>.Success(new upaccountOnGetSalerMainZetaResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options) });
    }
}