using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelected;

public class MoodUpdatesAktarmaSelectedCommandHandler
    (
    IDataManager dataManager,
    IDashBilancoMizanDefterManager dashBilancoMizanDefterManager,
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IDashGelirTablosuMizanDefterManager dashGelirTablosuMizanDefterManager,
    IReportSetMainAktarmaSqlOperationManager reportSetMainAktarmaSqlOperationManager
    ) : IRequestHandler<MoodUpdatesAktarmaSelectedCommand, GenericResult<MoodUpdatesAktarmaSelectedResponse>>
{
    public async Task<GenericResult<MoodUpdatesAktarmaSelectedResponse>> Handle(MoodUpdatesAktarmaSelectedCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.XMlookUpdate.caplist == null)
                return GenericResult<MoodUpdatesAktarmaSelectedResponse>.Fail("nok");

            string[] nlist = request.XMlookUpdate.caplist.Split(',');

            if (nlist.Length < 1)
                return GenericResult<MoodUpdatesAktarmaSelectedResponse>.Fail("nok");

            List<int> nlistint = nlist.Select(int.Parse).ToList();
            var currentUploadM = reportSetMainSqlOperationManager.Get_CompanyAktarmaResult(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var lastlist = currentUploadM.Where(x => nlistint.Contains(x.TypeID));
            var checklist = lastlist.Where(x => x.CheckValue != null && x.CheckValue != 0).ToList();
            List<DashAktarma> lastset = lastlist.Where(x => x.Value != 0).ToList();
            lastset.AddRange(checklist);

            List<int> nlistintlast = lastset.Select(x => x.TypeID).Distinct().ToList();
            reportSetMainAktarmaSqlOperationManager.Set_ReportStartAktarma(request.XMlookUpdate.year, request.XMlookUpdate.companyid, nlistintlast);

            long ide = -1000000 * request.XMlookUpdate.companyid;
            List<DashBilancoViewMizan> nRequestList = dashBilancoMizanDefterManager.getList(request.XMlookUpdate.year, ide);
            var tlist = dataManager.SetBilancoFromListMizan(nRequestList, ide, request.XMlookUpdate.year);
            dataManager.RESET_DashBilancoViewMizan(request.XMlookUpdate.year, ide);
            dataManager.InsertBilncoMzn(tlist);
            List<DashBilancoViewMizan> nRequestListRvn = dashGelirTablosuMizanDefterManager.getList(request.XMlookUpdate.year, ide);
            var tlistRvn = dataManager.SetBilancoFromListMizan(nRequestListRvn, ide, request.XMlookUpdate.year);
            dataManager.RESET_REVENUEViewMzn(request.XMlookUpdate.year, ide);
            dataManager.InsertRvnMzn(tlistRvn);

            List<DashBilancoViewMizan> nRequestList1 = dashBilancoMizanDefterManager.getList(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var tlist1 = dataManager.SetBilancoFromListMizan(nRequestList1, request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            dataManager.RESET_DashBilancoViewMizan(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            dataManager.InsertBilncoMzn(tlist1);
            List<DashBilancoViewMizan> nRequestListRvn1 = dashGelirTablosuMizanDefterManager.getList(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var tlistRvn1 = dataManager.SetBilancoFromListMizan(nRequestListRvn1, request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            dataManager.RESET_REVENUEViewMzn(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            dataManager.InsertRvnMzn(tlistRvn1);

            return GenericResult<MoodUpdatesAktarmaSelectedResponse>.Success(new MoodUpdatesAktarmaSelectedResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdatesAktarmaSelectedResponse>.Fail("nok " + ex.ToString());
        }
    }
}