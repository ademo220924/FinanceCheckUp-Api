using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerDate;
public class FinanceUploadMainOnGetSalerDateQueryHandler(
    IMainDashManager mainDashManager,
    IUploadMainManager uploadMainManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUploadMainOnGetSalerDateQuery, GenericResult<FinanceUploadMainOnGetSalerDateResponse>>
{
 

    public Task<GenericResult<FinanceUploadMainOnGetSalerDateResponse>> Handle(FinanceUploadMainOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;

        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        var curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        List<int> chkErrormonthID = mainDashManager.Get_DatabyError(request.InitialModel.CurrentUser.SelectedYear, curcomID)
            .Where(x => x.TErrorRowCount == 0)
            .Select(x => x.MainMonth)
            .ToList();
        var currentUploadM = uploadMainManager.Get_Data(request.InitialModel.CurrentUser.SelectedYear, curcomID);

        currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
         
        
                  return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerDateResponse>.Success(new FinanceUploadMainOnGetSalerDateResponse
                {
                    InitialModel = request.InitialModel,
                    Response = DataSourceLoader.Load(currentUploadM, request.Request.options)
                }));
    }
}
