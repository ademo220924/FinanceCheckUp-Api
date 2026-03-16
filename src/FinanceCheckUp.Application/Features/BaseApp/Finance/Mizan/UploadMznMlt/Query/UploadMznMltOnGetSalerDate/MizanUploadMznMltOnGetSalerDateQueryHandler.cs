using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznMlt.Query.UploadMznMltOnGetSalerDate
{
    public class MizanUploadMznMltOnGetSalerDateQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager) : IRequestHandler<MizanUploadMznMltOnGetSalerDateQuery, GenericResult<MizanUploadMznMltOnGetSalerDateResponse>>
    {
   

        public Task<GenericResult<MizanUploadMznMltOnGetSalerDateResponse>> Handle(MizanUploadMznMltOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            
            var currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyExcel(request.InitialModel.curcomID);
 
            
            return Task.FromResult(GenericResult<MizanUploadMznMltOnGetSalerDateResponse>.Success(new MizanUploadMznMltOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response= new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options))
            }));
        }
    }
}
