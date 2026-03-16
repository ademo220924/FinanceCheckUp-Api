using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetGraphCodeDel;
public class FinanceUpPageAktarmaJrnlOnGetGraphCodeDelQueryHandler(
    ITblxmJournalFileManager tblxmJournalFileManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetGraphCodeDelQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeDelResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeDelResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetGraphCodeDelQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        tblxmJournalFileManager.Delete_AllbyMainID(request.InitialModel.curcomID, request.Request.nyear, request.Request.ncode);
       
        return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeDelResponse>.Success(new FinanceUpPageAktarmaJrnlOnGetGraphCodeDelResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult("ok")
        }));
    }
}
