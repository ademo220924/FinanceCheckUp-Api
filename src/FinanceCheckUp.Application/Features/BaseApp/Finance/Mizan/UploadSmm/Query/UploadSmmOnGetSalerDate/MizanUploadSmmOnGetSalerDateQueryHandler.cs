using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadSmm.Query.UploadSmmOnGetSalerDate
{
    public class MizanUploadSmmOnGetSalerDateQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager) : IRequestHandler<MizanUploadSmmOnGetSalerDateQuery, GenericResult<MizanUploadSmmOnGetSalerDateResponse>>
    {
        public Task<GenericResult<MizanUploadSmmOnGetSalerDateResponse>> Handle(MizanUploadSmmOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            
            var currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyExcel(request.InitialModel.curcomID);

            return Task.FromResult(GenericResult<MizanUploadSmmOnGetSalerDateResponse>.Success(new MizanUploadSmmOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response= new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options))
            }));
        }
    }
}
