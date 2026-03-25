using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneProcess;

public class MoodUploadOneProcessCommandHandler(
    ICompanyManager companyManager,
    ITBLXmlManager tblXmlManager,
    IDataManager dataManager,
    IDashGelirTablosuViewMainManager dashGelirTablosuViewMainManager,
    IDashWCapitalViewMainManager dashWCapitalViewMainManager,
    IDashLikiditeViewMainManager dashLikiditeViewMainManager,
    IDashRasyoManager dashRasyoManager,
    IMainDashManager mainDashManager,
    IERRLOGManager errlogManager)
    : IRequestHandler<MoodUploadOneProcessCommand, GenericResult<MoodUploadOneProcessResponse>>
{
    public Task<GenericResult<MoodUploadOneProcessResponse>> Handle(MoodUploadOneProcessCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUploadOneProcessRequest.PageIndex;
        var file = pageIndex.file;
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];
        var comp = companyManager.Get_Company(Convert.ToInt32(pageIndex.ide));

        try
        {
            string retval = "ok";
            int fyear = Convert.ToInt32(fileyear);
            int fmonth = Convert.ToInt32(filemonth);
            int xmlid = tblXmlManager.GetComapnyIDByMonth(comp.Id, fmonth, fyear);
            dataManager.SetOpener(xmlid, filemonth, filemonth == "12");
            dataManager.SetHataLast(xmlid);
            dataManager.SetHataLastz(xmlid);
            dataManager.SetHataLastza(comp.Id, fyear);

            List<DashBilancoView> nRequestList = dashGelirTablosuViewMainManager.getList(fyear, comp.Id);
            var tlist = dataManager.SetBilancoFromList(nRequestList, comp.Id, fyear);
            dataManager.RESET_DashBilancoView(fyear, comp.Id);
            dataManager.InsertBilnco(tlist);
            List<DashBilancoView> nRequestListRvn = dashGelirTablosuViewMainManager.getList(fyear, comp.Id);
            var tlistRvn = dataManager.SetBilancoFromList(nRequestListRvn, comp.Id, fyear);
            dataManager.RESET_REVENUEView(fyear, comp.Id);
            var WCapitalViez = dashWCapitalViewMainManager.getList(fyear, comp.Id);
            var WCapitalVie = dataManager.SetBilancoFromList(WCapitalViez, comp.Id, fyear);
            var nLiqudity = dashLikiditeViewMainManager.getList(fyear, comp.Id);
            var WLiqudity = dataManager.SetBilancoFromList(nLiqudity, comp.Id, fyear);
            dataManager.InsertLiquidity(WLiqudity);
            dataManager.InsertWCapital(WCapitalVie);
            dataManager.InsertRvn(tlistRvn);
            dashRasyoManager.GetDashRasyoAnaliz(fyear, comp.Id);
            dashRasyoManager.GetDashLikiditeRiskTrend(fyear, comp.Id);
            dashRasyoManager.GetDashOzetMali(fyear, comp.Id, Convert.ToInt32(filemonth));
            mainDashManager.Get_DatabyErrorV1(fyear, comp.Id, Convert.ToInt32(filemonth));

            return Task.FromResult(GenericResult<MoodUploadOneProcessResponse>.Success(
                new MoodUploadOneProcessResponse { ResultText = new JsonResult(retval) }));
        }
        catch (Exception ex)
        {
            errlogManager.Save_AppLogs(new ERRLOG
            {
                CompanyID = comp.Id,
                CsvID = 7777,
                ERLOG = ex.ToString()
            });
            return Task.FromResult(GenericResult<MoodUploadOneProcessResponse>.Success(
                new MoodUploadOneProcessResponse { ResultText = new JsonResult("nok") }));
        }
    }
}
