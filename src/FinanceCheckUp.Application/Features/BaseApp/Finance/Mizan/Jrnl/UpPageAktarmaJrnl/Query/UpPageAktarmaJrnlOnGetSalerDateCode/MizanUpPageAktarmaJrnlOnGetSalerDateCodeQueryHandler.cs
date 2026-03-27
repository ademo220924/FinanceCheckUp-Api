using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerDateCode;
public class MizanUpPageAktarmaJrnlOnGetSalerDateCodeQueryHandler(
    ITblxmJournalFileManager tblxmJournalFileManager,IHhvnUsersManager hhvnUsersManager,  ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetSalerDateCodeQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateCodeResponse>>
{
   
    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateCodeResponse>> Handle(MizanUpPageAktarmaJrnlOnGetSalerDateCodeQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt32(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(userId);

        
         
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);

        request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;


        var currentUploadM1 = tblxmJournalFileManager.Get_AllbycompzCodeMain(request.Request.nyear, request.InitialModel.curcomID);

        DataSourceLoadOptions options = new DataSourceLoadOptions();
 
                return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateCodeResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetSalerDateCodeResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(currentUploadM1, options)
            }));
    }
}
