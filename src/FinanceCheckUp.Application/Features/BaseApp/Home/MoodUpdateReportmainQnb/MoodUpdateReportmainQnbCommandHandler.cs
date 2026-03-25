using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReportmainQnb;

public class MoodUpdateReportmainQnbCommandHandler(
    IDashBilancoViewMainQnbManager dashBilancoViewMainQnbManager,
    IDashBilancoViewMainQnbGelirManager dashBilancoViewMainQnbGelirManager,
    IDataManager dataManager)
    : IRequestHandler<MoodUpdateReportmainQnbCommand, GenericResult<MoodUpdateReportmainQnbResponse>>
{
    public Task<GenericResult<MoodUpdateReportmainQnbResponse>> Handle(MoodUpdateReportmainQnbCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateReportmainQnbRequest.PageIndex;
        try
        {
            List<DashBilancoViewQnb> nRequestList = dashBilancoViewMainQnbManager.getList(pageIndex.year, pageIndex.companyid);
            var tlist = dataManager.SetBilancoFromListQnb(nRequestList, pageIndex.companyid, pageIndex.year, 1);

            List<DashBilancoViewQnb> nRequestLista = dashBilancoViewMainQnbManager.getListToplam(pageIndex.year, pageIndex.companyid);
            var tlista = dataManager.SetBilancoFromListQnb(nRequestLista, pageIndex.companyid, pageIndex.year, 2);

            List<DashBilancoViewQnb> nRequestList1 = dashBilancoViewMainQnbManager.getListA(pageIndex.year, pageIndex.companyid);
            var tlist1 = dataManager.SetBilancoFromListQnb(nRequestList1, pageIndex.companyid, pageIndex.year, 3);

            List<DashBilancoViewQnb> nRequestList1a = dashBilancoViewMainQnbManager.getListAToplam(pageIndex.year, pageIndex.companyid);
            var tlist1a = dataManager.SetBilancoFromListQnb(nRequestList1a, pageIndex.companyid, pageIndex.year, 4);

            List<DashBilancoViewQnb> nRequestList3 = dashBilancoViewMainQnbManager.getListB(pageIndex.year, pageIndex.companyid);
            var tlist3 = dataManager.SetBilancoFromListQnb(nRequestList3, pageIndex.companyid, pageIndex.year, 5);

            List<DashBilancoViewQnb> nRequestList3a = dashBilancoViewMainQnbManager.getListBToplam(pageIndex.year, pageIndex.companyid);
            var tlist3a = dataManager.SetBilancoFromListQnb(nRequestList3a, pageIndex.companyid, pageIndex.year, 6);

            List<DashBilancoViewQnb> nRequestList5 = dashBilancoViewMainQnbManager.getListC(pageIndex.year, pageIndex.companyid);
            var tlist5 = dataManager.SetBilancoFromListQnb(nRequestList5, pageIndex.companyid, pageIndex.year, 7);

            List<DashBilancoViewQnb> nRequestList5a = dashBilancoViewMainQnbManager.getListCToplam(pageIndex.year, pageIndex.companyid);
            var tlist5a = dataManager.SetBilancoFromListQnb(nRequestList5a, pageIndex.companyid, pageIndex.year, 8);

            List<DashBilancoViewQnb> nRequestList7 = dashBilancoViewMainQnbManager.getListD(pageIndex.year, pageIndex.companyid);
            var tlist7 = dataManager.SetBilancoFromListQnb(nRequestList7, pageIndex.companyid, pageIndex.year, 9);

            List<DashBilancoViewQnb> nRequestList7a = dashBilancoViewMainQnbManager.getListDToplam(pageIndex.year, pageIndex.companyid);
            var tlist7a = dataManager.SetBilancoFromListQnb(nRequestList7a, pageIndex.companyid, pageIndex.year, 11);

            tlist.AddRange(tlista);
            tlist.AddRange(tlist1);
            tlist.AddRange(tlist1a);
            tlist.AddRange(tlist3);
            tlist.AddRange(tlist3a);
            tlist.AddRange(tlist5);
            tlist.AddRange(tlist5a);
            tlist.AddRange(tlist7);
            tlist.AddRange(tlist7a);
            dataManager.InsertBilncoQnb(tlist);

            List<DashBilancoViewQnb> nRequestList21 = dashBilancoViewMainQnbGelirManager.getList(pageIndex.year, pageIndex.companyid);
            var tlist21 = dataManager.SetBilancoFromListQnb(nRequestList21, pageIndex.companyid, pageIndex.year, 13);

            List<DashBilancoViewQnb> nRequestList21a = dashBilancoViewMainQnbGelirManager.getListA(pageIndex.year, pageIndex.companyid);
            var tlist21a = dataManager.SetBilancoFromListQnb(nRequestList21a, pageIndex.companyid, pageIndex.year, 15);

            List<DashBilancoViewQnb> nRequestList21b = dashBilancoViewMainQnbGelirManager.getListB(pageIndex.year, pageIndex.companyid);
            var tlist21b = dataManager.SetBilancoFromListQnb(nRequestList21b, pageIndex.companyid, pageIndex.year, 17);

            List<DashBilancoViewQnb> nRequestList21c = dashBilancoViewMainQnbGelirManager.getListC(pageIndex.year, pageIndex.companyid);
            var tlist21c = dataManager.SetBilancoFromListQnb(nRequestList21c, pageIndex.companyid, pageIndex.year, 19);

            List<DashBilancoViewQnb> nRequestList21d = dashBilancoViewMainQnbGelirManager.getListD(pageIndex.year, pageIndex.companyid);
            var tlist21d = dataManager.SetBilancoFromListQnb(nRequestList21d, pageIndex.companyid, pageIndex.year, 21);

            List<DashBilancoViewQnb> nRequestList21e = dashBilancoViewMainQnbGelirManager.getListE(pageIndex.year, pageIndex.companyid);
            var tlist21e = dataManager.SetBilancoFromListQnb(nRequestList21e, pageIndex.companyid, pageIndex.year, 23);

            List<DashBilancoViewQnb> nRequestList21f = dashBilancoViewMainQnbGelirManager.getListF(pageIndex.year, pageIndex.companyid);
            var tlist21f = dataManager.SetBilancoFromListQnb(nRequestList21f, pageIndex.companyid, pageIndex.year, 25);

            List<DashBilancoViewQnb> nRequestList21g = dashBilancoViewMainQnbGelirManager.getListG(pageIndex.year, pageIndex.companyid);
            var tlist21g = dataManager.SetBilancoFromListQnb(nRequestList21g, pageIndex.companyid, pageIndex.year, 27);

            List<DashBilancoViewQnb> nRequestList21h = dashBilancoViewMainQnbGelirManager.getListH(pageIndex.year, pageIndex.companyid);
            var tlist21h = dataManager.SetBilancoFromListQnb(nRequestList21h, pageIndex.companyid, pageIndex.year, 29);

            List<DashBilancoViewQnb> nRequestList21i = dashBilancoViewMainQnbGelirManager.getListI(pageIndex.year, pageIndex.companyid);
            var tlist21i = dataManager.SetBilancoFromListQnb(nRequestList21i, pageIndex.companyid, pageIndex.year, 31);

            tlist21.AddRange(tlist21a);
            tlist21.AddRange(tlist21b);
            tlist21.AddRange(tlist21c);
            tlist21.AddRange(tlist21d);
            tlist21.AddRange(tlist21e);
            tlist21.AddRange(tlist21f);
            tlist21.AddRange(tlist21g);
            tlist21.AddRange(tlist21h);
            tlist21.AddRange(tlist21i);
            dataManager.InsertBilncoQnbGelir(tlist21);
            dashBilancoViewMainQnbGelirManager.setListSektor(pageIndex.year, pageIndex.companyid);
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateReportmainQnbResponse>.Success(
                new MoodUpdateReportmainQnbResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateReportmainQnbResponse>.Success(
            new MoodUpdateReportmainQnbResponse { ResultText = new JsonResult("ok") }));
    }
}
