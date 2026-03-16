using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerDateMain;
public class MizanUpPageAktarmaJrnlOnGetSalerDateMainQueryHandler(ITblxmJournalFileManager tblxmJournalFileManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetSalerDateMainQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateMainResponse>>
{
   

    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateMainResponse>> Handle(MizanUpPageAktarmaJrnlOnGetSalerDateMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(userId);

        
         
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        var curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;


        var currentUploadM1 = tblxmJournalFileManager.Get_Allbycompz(request.Request.nyear, curcomID);

        DataSourceLoadOptions options = new DataSourceLoadOptions();
 
        
        return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateMainResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetSalerDateMainResponse
            {
                InitialModel = request.InitialModel,
                Response = new JsonResult(DataSourceLoader.Load(currentUploadM1, options))
            }));
    }
}

