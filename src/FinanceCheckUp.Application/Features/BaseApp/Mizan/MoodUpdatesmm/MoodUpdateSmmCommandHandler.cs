using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Mizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Mizan.MoodUpdatesmm;

public class MoodUpdateSmmCommandHandler
(
  IDataManager dataManager,
  IDashBilancoSetMizanManager dashBilancoSetMizanManager,
  IDashBilancoMizanManager dashBilancoMizanManager,
  IDashGelirTablosuMizanManager dashGelirTablosuMizanManager
) : IRequestHandler<MoodUpdateSmmCommand, GenericResult<MoodUpdateSmmResponse>>
{
    public async Task<GenericResult<MoodUpdateSmmResponse>> Handle(MoodUpdateSmmCommand request, CancellationToken cancellationToken)
    {
        try
        {
            dashBilancoSetMizanManager.SET_Stat(request.XMlookUpdate.year, request.XMlookUpdate.companyid, request.XMlookUpdate.month);
            List<DashBilancoViewMizan> nRequestList = dashBilancoMizanManager.getList(request.XMlookUpdate.year, -1 * request.XMlookUpdate.companyid);
            var tlist = dataManager.SetBilancoFromListMizan(nRequestList, -1 * request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            dataManager.RESET_DashBilancoViewMizan(request.XMlookUpdate.year, -1 * request.XMlookUpdate.companyid);
            dataManager.InsertBilncoMzn(tlist);
            List<DashBilancoViewMizan> nRequestListRvn = dashGelirTablosuMizanManager.getList(request.XMlookUpdate.year, -1 * request.XMlookUpdate.companyid);
            var tlistRvn = dataManager.SetBilancoFromListMizan(nRequestListRvn, -1 * request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            dataManager.RESET_REVENUEViewMzn(request.XMlookUpdate.year, -1 * request.XMlookUpdate.companyid);
            dataManager.InsertRvnMzn(tlistRvn);


            List<DashBilancoViewMizan> nRequestList1 = dashBilancoMizanManager.getList(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var tlist1 = dataManager.SetBilancoFromListMizan(nRequestList1, request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            dataManager.RESET_DashBilancoViewMizan(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            dataManager.InsertBilncoMzn(tlist1);
            List<DashBilancoViewMizan> nRequestListRvn1 = dashGelirTablosuMizanManager.getList(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            var tlistRvn1 = dataManager.SetBilancoFromListMizan(nRequestListRvn1, request.XMlookUpdate.companyid, request.XMlookUpdate.year);
            dataManager.RESET_REVENUEViewMzn(request.XMlookUpdate.year, request.XMlookUpdate.companyid);
            dataManager.InsertRvnMzn(tlistRvn1);
            dashBilancoSetMizanManager.Set_ReportSetMainSMM(request.XMlookUpdate.year, -1 * request.XMlookUpdate.companyid);

            return GenericResult<MoodUpdateSmmResponse>.Success(new MoodUpdateSmmResponse() { ResultText = new JsonResult("ok") });
        }
        catch (Exception ex)
        {
            return GenericResult<MoodUpdateSmmResponse>.Fail("nok " + ex.ToString());
        }
    }
}