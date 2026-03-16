using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelectedMzn;

public class MoodUpdatesAktarmaSelectedMznCommandHandler
    (
    IDataManager dataManager,
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IDashGelirTablosuMizanManager dashGelirTablosuDefterManager,
    IReportSetMainAktarmaSqlOperationManager reportSetMainAktarmaSqlOperationManager,
    IDashBilancoMizanManager dashBilancoMizanManager,
    IBeyannameChkManager beyannameChkManager
    ) : IRequestHandler<MoodUpdatesAktarmaSelectedMznCommand, GenericResult<MoodUpdatesAktarmaSelectedMznResponse>>
{
    public async Task<GenericResult<MoodUpdatesAktarmaSelectedMznResponse>> Handle(MoodUpdatesAktarmaSelectedMznCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.XMlookUpdate.caplist == null)
                return GenericResult<MoodUpdatesAktarmaSelectedMznResponse>.Fail("nok");

            string[] nlist = request.XMlookUpdate.caplist.Split(',');

            if (nlist.Length < 1)
                return GenericResult<MoodUpdatesAktarmaSelectedMznResponse>.Fail("nok");

            List<int> nlistint = nlist.Select(int.Parse).ToList();
            var currentUploadM = reportSetMainSqlOperationManager.Get_CompanyAktarmaResult(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var lastlist = currentUploadM.Where(x => nlistint.Contains(x.TypeID));
            var checklist = lastlist.Where(x => x.CheckValue != null && x.CheckValue != 0).ToList();
            List<DashAktarma> lastset = lastlist.Where(x => x.Value != 0).ToList();
            lastset.AddRange(checklist);

            List<int> nlistintlast = lastset.Select(x => x.TypeID).Distinct().ToList();
            reportSetMainAktarmaSqlOperationManager.Set_ReportStartAktarma(request.XMlookUpdate.year, request.XMlookUpdate.companyid, nlistintlast);
            List<DashBilancoViewMizan> nRequestList = new List<DashBilancoViewMizan>();
            long ide = -1000000 * request.XMlookUpdate.companyid;
            int chk = beyannameChkManager.Get_BeyannameCountChk(request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            if (chk > 1)
                nRequestList = dashBilancoMizanManager.getListbynmizan(request.XMlookUpdate.year, ide);
            else
                nRequestList = dashBilancoMizanManager.getListbynmizan(request.XMlookUpdate.year, ide, 1);

            var tlist = dataManager.SetBilancoFromListMizan(nRequestList, ide, request.XMlookUpdate.year);
            dataManager.RESET_DashBilancoViewMizan(request.XMlookUpdate.year, ide);
            dataManager.InsertBilncoMzn(tlist);
            List<DashBilancoViewMizan> nRequestListRvn = dashGelirTablosuDefterManager.getList(request.XMlookUpdate.year, ide);
            var tlistRvn = dataManager.SetBilancoFromListMizan(nRequestListRvn, ide, request.XMlookUpdate.year);
            dataManager.RESET_REVENUEViewMzn(request.XMlookUpdate.year, ide);
            dataManager.InsertRvnMzn(tlistRvn);

            return GenericResult<MoodUpdatesAktarmaSelectedMznResponse>.Success(new MoodUpdatesAktarmaSelectedMznResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdatesAktarmaSelectedMznResponse>.Fail("nok" + ex.ToString());
        }
    }

}
