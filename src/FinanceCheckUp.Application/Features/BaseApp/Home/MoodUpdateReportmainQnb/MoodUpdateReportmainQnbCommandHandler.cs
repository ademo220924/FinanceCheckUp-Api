using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateReportmainQnb;

public class MoodUpdateReportmainQnbCommandHandler: IRequestHandler<MoodUpdateReportmainQnbCommand, GenericResult<MoodUpdateReportmainQnbResponse>>
{
    public Task<GenericResult<MoodUpdateReportmainQnbResponse>> Handle(MoodUpdateReportmainQnbCommand request, CancellationToken cancellationToken)
    {
       if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {

            List<DashBilancoViewQnb> nRequestList = DashBilancoViewMainQnb.getList(pageIndex.year, pageIndex.companyid);
            var tlist = Data.SetBilancoFromListQnb(nRequestList, pageIndex.companyid, pageIndex.year, 1);

            List<DashBilancoViewQnb> nRequestLista = DashBilancoViewMainQnb.getListToplam(pageIndex.year, pageIndex.companyid);
            var tlista = Data.SetBilancoFromListQnb(nRequestLista, pageIndex.companyid, pageIndex.year, 2);

            List<DashBilancoViewQnb> nRequestList1 = DashBilancoViewMainQnb.getListA(pageIndex.year, pageIndex.companyid);
            var tlist1 = Data.SetBilancoFromListQnb(nRequestList1, pageIndex.companyid, pageIndex.year, 3);

            List<DashBilancoViewQnb> nRequestList1a = DashBilancoViewMainQnb.getListAToplam(pageIndex.year, pageIndex.companyid);
            var tlist1a = Data.SetBilancoFromListQnb(nRequestList1a, pageIndex.companyid, pageIndex.year, 4);

            List<DashBilancoViewQnb> nRequestList3 = DashBilancoViewMainQnb.getListB(pageIndex.year, pageIndex.companyid);
            var tlist3 = Data.SetBilancoFromListQnb(nRequestList3, pageIndex.companyid, pageIndex.year, 5);

            List<DashBilancoViewQnb> nRequestList3a = DashBilancoViewMainQnb.getListBToplam(pageIndex.year, pageIndex.companyid);
            var tlist3a = Data.SetBilancoFromListQnb(nRequestList3a, pageIndex.companyid, pageIndex.year, 6);

            List<DashBilancoViewQnb> nRequestList5 = DashBilancoViewMainQnb.getListC(pageIndex.year, pageIndex.companyid);
            var tlist5 = Data.SetBilancoFromListQnb(nRequestList5, pageIndex.companyid, pageIndex.year, 7);

            List<DashBilancoViewQnb> nRequestList5a = DashBilancoViewMainQnb.getListCToplam(pageIndex.year, pageIndex.companyid);
            var tlist5a = Data.SetBilancoFromListQnb(nRequestList5a, pageIndex.companyid, pageIndex.year, 8);

            List<DashBilancoViewQnb> nRequestList7 = DashBilancoViewMainQnb.getListD(pageIndex.year, pageIndex.companyid);
            var tlist7 = Data.SetBilancoFromListQnb(nRequestList7, pageIndex.companyid, pageIndex.year, 9);

            List<DashBilancoViewQnb> nRequestList7a = DashBilancoViewMainQnb.getListDToplam(pageIndex.year, pageIndex.companyid);
            var tlist7a = Data.SetBilancoFromListQnb(nRequestList7a, pageIndex.companyid, pageIndex.year, 11);


            tlist.AddRange(tlista);
            tlist.AddRange(tlist1);
            tlist.AddRange(tlist1a);
            tlist.AddRange(tlist3);
            tlist.AddRange(tlist3a);
            tlist.AddRange(tlist5);
            tlist.AddRange(tlist5a);
            tlist.AddRange(tlist7);
            tlist.AddRange(tlist7a);
            Data.InsertBilncoQnb(tlist);



            List<DashBilancoViewQnb> nRequestList21 = DashBilancoViewMainQnbGelir.getList(pageIndex.year, pageIndex.companyid);
            var tlist21 = Data.SetBilancoFromListQnb(nRequestList21, pageIndex.companyid, pageIndex.year, 13);

            List<DashBilancoViewQnb> nRequestList21a = DashBilancoViewMainQnbGelir.getListA(pageIndex.year, pageIndex.companyid);
            var tlist21a = Data.SetBilancoFromListQnb(nRequestList21a, pageIndex.companyid, pageIndex.year, 15);

            List<DashBilancoViewQnb> nRequestList21b = DashBilancoViewMainQnbGelir.getListB(pageIndex.year, pageIndex.companyid);
            var tlist21b = Data.SetBilancoFromListQnb(nRequestList21b, pageIndex.companyid, pageIndex.year, 17);

            List<DashBilancoViewQnb> nRequestList21c = DashBilancoViewMainQnbGelir.getListC(pageIndex.year, pageIndex.companyid);
            var tlist21c = Data.SetBilancoFromListQnb(nRequestList21c, pageIndex.companyid, pageIndex.year, 19);

            List<DashBilancoViewQnb> nRequestList21d = DashBilancoViewMainQnbGelir.getListD(pageIndex.year, pageIndex.companyid);
            var tlist21d = Data.SetBilancoFromListQnb(nRequestList21d, pageIndex.companyid, pageIndex.year, 21);

            List<DashBilancoViewQnb> nRequestList21e = DashBilancoViewMainQnbGelir.getListE(pageIndex.year, pageIndex.companyid);
            var tlist21e = Data.SetBilancoFromListQnb(nRequestList21e, pageIndex.companyid, pageIndex.year, 23);


            List<DashBilancoViewQnb> nRequestList21f = DashBilancoViewMainQnbGelir.getListF(pageIndex.year, pageIndex.companyid);
            var tlist21f = Data.SetBilancoFromListQnb(nRequestList21f, pageIndex.companyid, pageIndex.year, 25);

            List<DashBilancoViewQnb> nRequestList21g = DashBilancoViewMainQnbGelir.getListG(pageIndex.year, pageIndex.companyid);
            var tlist21g = Data.SetBilancoFromListQnb(nRequestList21g, pageIndex.companyid, pageIndex.year, 27);

            List<DashBilancoViewQnb> nRequestList21h = DashBilancoViewMainQnbGelir.getListH(pageIndex.year, pageIndex.companyid);
            var tlist21h = Data.SetBilancoFromListQnb(nRequestList21h, pageIndex.companyid, pageIndex.year, 29);

            List<DashBilancoViewQnb> nRequestList21i = DashBilancoViewMainQnbGelir.getListI(pageIndex.year, pageIndex.companyid);
            var tlist21i = Data.SetBilancoFromListQnb(nRequestList21i, pageIndex.companyid, pageIndex.year, 31);

            tlist21.AddRange(tlist21a);
            tlist21.AddRange(tlist21b);
            tlist21.AddRange(tlist21c);
            tlist21.AddRange(tlist21d);
            tlist21.AddRange(tlist21e);
            tlist21.AddRange(tlist21f);
            tlist21.AddRange(tlist21g);
            tlist21.AddRange(tlist21h);
            tlist21.AddRange(tlist21i);
            Data.InsertBilncoQnbGelir(tlist21);
            DashBilancoViewMainQnbGelir.setListSektor(pageIndex.year, pageIndex.companyid);
            //ReportSetMain.Set_ReportSetMain(pageIndex.year, pageIndex.companyid);
            // int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");
    }
}
