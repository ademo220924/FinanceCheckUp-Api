using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetSalerDateMain;
public class FinanceUpPageAktarmaJrnlOnGetSalerDateMainQueryHandler(
    ITblxmJournalFileManager tblxmJournalFileManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetSalerDateMainQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateMainResponse>>
{

    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateMainResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetSalerDateMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM1 = tblxmJournalFileManager.Get_Allbycompz(request.Request.nyear, request.InitialModel.curcomID);
        var options = new DataSourceLoadOptions();
        
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateMainResponse>.Success(new FinanceUpPageAktarmaJrnlOnGetSalerDateMainResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(currentUploadM1, options)
        }));
        
    }
}
