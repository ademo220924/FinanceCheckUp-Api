using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.StaticManagers;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetGraphCodeDel;
public class MizanUpPageAktarmaJrnlOnGetGraphCodeDelQueryHandler(
    IDashGelirTablosuMizanDefterManager dashGelirTablosuMizanDefterManager,
    IDashBilancoMizanDefterManager dashBilancoMizanDefterManager,
    IDataManager dataManager,
    IDashOzetMaliMizanManager dashOzetMaliMizanManager,
    ITblxmJournalFileManager tblxmJournalFileManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetGraphCodeDelQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetGraphCodeDelResponse>>
{
   

    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetGraphCodeDelResponse>> Handle(MizanUpPageAktarmaJrnlOnGetGraphCodeDelQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        request.InitialModel.UserID = userId;
        
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        tblxmJournalFileManager.Delete_AllbyMainID(request.InitialModel.curcomID, request.Request.nyear, request.Request.ncode);

        long ide = -1000000 * request.InitialModel.curcomID;
        tblxmJournalFileManager.Update_AllbyMainID(ide, request.Request.nyear, request.Request.ncode);
        List<DashBilancoViewMizan> nRequestList = dashBilancoMizanDefterManager.getList(request.Request.nyear, ide);
        var tlist = dataManager.SetBilancoFromListMizan(nRequestList, ide, request.Request.nyear);
        dataManager.RESET_DashBilancoViewMizan(request.Request.nyear, ide);
        dataManager.InsertBilncoMzn(tlist);
        List<DashBilancoViewMizan> nRequestListRvn = dashGelirTablosuMizanDefterManager.getList(request.Request.nyear, ide);
        var tlistRvn = dataManager.SetBilancoFromListMizan(nRequestListRvn, ide, request.Request.nyear);
        dataManager.RESET_REVENUEViewMzn(request.Request.nyear, ide);
        dataManager.InsertRvnMzn(tlistRvn);

        dashOzetMaliMizanManager.ClearFibaPr(request.InitialModel.curcomID);

     
        return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetGraphCodeDelResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetGraphCodeDelResponse
            {
                InitialModel = request.InitialModel
            }));
 
    }
}