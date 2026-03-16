using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetGraphCode;
public class FinanceUpPageAktarmaJrnlOnGetGraphCodeQueryHandler(
    ITblxmJournalFileManager tblxmJournalFileManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetGraphCodeQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetGraphCodeQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        var nfile = new  TblxmJournalFile
        {
            DebitCredit = request.Request.ncodedc,
            Year = request.Request.nyear,
            AccountMainId = request.Request.ncode,
            Amount = request.Request.nvalue,
            CompanyId = request.InitialModel.curcomID
        };

        tblxmJournalFileManager.Save_(nfile);
        return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetGraphCodeResponse>.Success(new FinanceUpPageAktarmaJrnlOnGetGraphCodeResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult("ok")
        }));
    }
}
