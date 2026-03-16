using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetGraphCode;
public class MizanUpPageAktarmaJrnlOnGetGraphCodeQueryHandler(
    IDashGelirTablosuMizanDefterManager dashGelirTablosuMizanDefterManager,
    IDashBilancoMizanDefterManager dashBilancoMizanDefterManager,
    IDataManager dataManager,
    IDashOzetMaliMizanManager dashOzetMaliMizanManager,
    ITblxmJournalFileManager tblxmJournalFileManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetGraphCodeQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetGraphCodeResponse>>
{
    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetGraphCodeResponse>> Handle(MizanUpPageAktarmaJrnlOnGetGraphCodeQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);

        request.InitialModel.UserID = userId;
        
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM1 = tblxmJournalFileManager.Get_AllbycompzCode(request.Request.nyear, request.InitialModel.curcomID);


        if (currentUploadM1.Where(x => x.AccountMainID.Trim() == request.Request.ncode.Trim()).Count() < 1)
        {
            tblxmJournalFileManager.Get_AllbycompzCodeInsert(request.Request.nyear, request.InitialModel.curcomID, request.Request.ncode);
        }


        TblxmJournalFile nfile = new TblxmJournalFile();
        nfile.DebitCredit = request.Request.ncodedc;
        nfile.Year = request.Request.nyear;

        nfile.AccountMainId = request.Request.ncode;
        nfile.Amount = request.Request.nvalue;

        nfile.CompanyId = request.InitialModel.curcomID;
        tblxmJournalFileManager.Save_(nfile);

        long ide = -1000000 * request.InitialModel.curcomID;

        dashOzetMaliMizanManager.SetJournnal(request.Request.nyear, request.InitialModel.curcomID);
        List<DashBilancoViewMizan> nRequestList = dashBilancoMizanDefterManager.getList(request.Request.nyear, ide);
        var tlist = dataManager.SetBilancoFromListMizan(nRequestList, ide, request.Request.nyear);
        dataManager.RESET_DashBilancoViewMizan(request.Request.nyear, ide);
        dataManager.InsertBilncoMzn(tlist);
        List<DashBilancoViewMizan> nRequestListRvn = dashGelirTablosuMizanDefterManager.getList(request.Request.nyear, ide);
        var tlistRvn = dataManager.SetBilancoFromListMizan(nRequestListRvn, ide, request.Request.nyear);
        dataManager.RESET_REVENUEViewMzn(request.Request.nyear, ide);
        dataManager.InsertRvnMzn(tlistRvn);

        dashOzetMaliMizanManager.ClearFibaPr(request.InitialModel.curcomID);
        return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetGraphCodeResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetGraphCodeResponse
            {
                InitialModel = request.InitialModel,
                Response =  new JsonResult("ok")
            }));
    }
}