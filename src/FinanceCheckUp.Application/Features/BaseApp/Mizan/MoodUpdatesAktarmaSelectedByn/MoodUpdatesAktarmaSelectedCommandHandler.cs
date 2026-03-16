using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesAktarmaSelectedByn;

public class MoodUpdatesAktarmaSelectedBynCommandHandler
    (
    IDataManager dataManager,
    IDashBilancoBeyanManager dashBilancoBeyanManager,
    IDashGelirTablosuMizanManager dashGelirTablosuMizanManager,
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IReportSetMainAktarmaSqlOperationManager reportSetMainAktarmaSqlOperationManager
    ) : IRequestHandler<MoodUpdatesAktarmaSelectedBynCommand, GenericResult<MoodUpdateSaktarmaSelectedByNResponse>>
{
    public async Task<GenericResult<MoodUpdateSaktarmaSelectedByNResponse>> Handle(MoodUpdatesAktarmaSelectedBynCommand request, CancellationToken cancellationToken)
    {
        try
        {

            if (request.XMlookUpdate.caplist == null)
                return GenericResult<MoodUpdateSaktarmaSelectedByNResponse>.Fail("nok");

            string[] nlist = request.XMlookUpdate.caplist.Split(',');

            if (nlist.Length < 1)
                return GenericResult<MoodUpdateSaktarmaSelectedByNResponse>.Fail("nok");

            List<int> nlistint = nlist.Select(int.Parse).ToList();
            var currentUploadM = reportSetMainSqlOperationManager.Get_CompanyAktarmaResult(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var lastlist = currentUploadM.Where(x => nlistint.Contains(x.TypeID));
            var checklist = lastlist.Where(x => x.CheckValue != null && x.CheckValue != 0).ToList();
            List<DashAktarma> lastset = lastlist.Where(x => x.Value != 0).ToList();
            lastset.AddRange(checklist);

            List<int> nlistintlast = lastset.Select(x => x.TypeID).Distinct().ToList();
            //ReportSetMainAktarma.Set_ReportSetfirst(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            reportSetMainAktarmaSqlOperationManager.Set_ReportStartAktarma(request.XMlookUpdate.year, request.XMlookUpdate.companyid, nlistintlast);

            long ide = -1000000 * request.XMlookUpdate.companyid;
            List<DashBilancoViewMizan> nRequestList = dashBilancoBeyanManager.getList(request.XMlookUpdate.year, ide);
            var tlist = dataManager.SetBilancoFromListMizan(nRequestList, ide, request.XMlookUpdate.year);
            dataManager.RESET_DashBilancoViewMizan(request.XMlookUpdate.year, ide);
            dataManager.InsertBilncoMzn(tlist);
            List<DashBilancoViewMizan> nRequestListRvn = dashGelirTablosuMizanManager.getList(request.XMlookUpdate.year, ide);
            var tlistRvn = dataManager.SetBilancoFromListMizan(nRequestListRvn, ide, request.XMlookUpdate.year);
            dataManager.RESET_REVENUEViewMzn(request.XMlookUpdate.year, ide);
            dataManager.InsertRvnMzn(tlistRvn);

            return GenericResult<MoodUpdateSaktarmaSelectedByNResponse>.Success(new MoodUpdateSaktarmaSelectedByNResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdateSaktarmaSelectedByNResponse>.Fail("nok");
        }
    }
}