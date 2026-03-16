using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGetSalerDate
{
    public class MizanUploadMainOnGetSalerDateQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager, 
        IMainDashManager mainDashManager,
        IUploadMainManager uploadMainManager) : IRequestHandler<MizanUploadMainOnGetSalerDateQuery, GenericResult<MizanUploadMainOnGetSalerDateResponse>>
    {
        public Task<GenericResult<MizanUploadMainOnGetSalerDateResponse>> Handle(MizanUploadMainOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId; 
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            var chkErrormonthID = mainDashManager.Get_DatabyError(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID).Where(x => x.TErrorRowCount == 0).Select(x => x.MainMonth).ToList();
            var currentUploadM = uploadMainManager.Get_Data(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID);
            currentUploadM=currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
            
            return Task.FromResult(GenericResult<MizanUploadMainOnGetSalerDateResponse>.Success(new MizanUploadMainOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response=  new JsonResult(DataSourceLoader.Load(currentUploadM, request.Request.options))
            }));
        }
    }
}
