using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.ViewModel;

public class ReportKapak
{

    public static ReportKapak setKapak(IEnumerable<ReportMainItem> nlist)
    {
        ReportKapak nkapak = new ReportKapak();
        nkapak.nitemCariOran = nlist.Where(x => x.TypeID == 11).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 11).FirstOrDefault();
        nkapak.nitemLikitideOran = nlist.Where(x => x.TypeID == 33).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 33).FirstOrDefault();
        nkapak.nitemNakitOran = nlist.Where(x => x.TypeID == 55).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 55).FirstOrDefault();
        nkapak.nitemAlacakDevir = nlist.Where(x => x.TypeID == 171).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 171).FirstOrDefault();
        nkapak.nitemTicariBorcDevir = nlist.Where(x => x.TypeID == 101).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 101).FirstOrDefault();
        nkapak.nitemStokDevir = nlist.Where(x => x.TypeID == 99).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 99).FirstOrDefault();
        nkapak.nitemBorcOzsermaye = nlist.Where(x => x.TypeID == 141).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 141).FirstOrDefault();
        nkapak.nitemTpolamBankaBorc = nlist.Where(x => x.TypeID == 161).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 161).FirstOrDefault();
        nkapak.nitemOzkaynakAktif = nlist.Where(x => x.TypeID == 201).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 201).FirstOrDefault();
        nkapak.nitemOzsermayeKarlilik = nlist.Where(x => x.TypeID == 181).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 181).FirstOrDefault();
        nkapak.nitemNetIsletmeSermaye = nlist.Where(x => x.TypeID == 121).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 121).FirstOrDefault();
        nkapak.nitemNetSatisBuyumeOran = nlist.Where(x => x.TypeID == 191).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 191).FirstOrDefault();
        nkapak.nitemROAAktifKarlilik = nlist.Where(x => x.TypeID == 221).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 221).FirstOrDefault();
        nkapak.nitemAltmanz = nlist.Where(x => x.TypeID == 251).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 251).FirstOrDefault();
        nkapak.nitemFaizVergiOncesiKarZarar = nlist.Where(x => x.TypeID == 231).FirstOrDefault() == null ? new ReportMainItem() : nlist.Where(x => x.TypeID == 231).FirstOrDefault();
        return nkapak;
    }

    //    GroupName CounterZone
    //Cari Oranı	11
    //Likitide Oranı	33
    //Nakit Oranı(%)  55
    //Ortalama Tahsil Süresi	77
    //Stok Devir Hızı	99
    //Borç Devir Hızı	101
    //Net İşletme Sermayesi	121
    //Toplam Borç / Özsermaye Oranı	141
    //Kısa vadeli Banka borçları/Net Satışlar	161
    //Alacak Devir Hızı	171
    //Özsermaye Karlılığı	181
    //Net Satış Büyüme Oranı	191
    public ReportMainItem nitemAltmanz { get; set; }
    public ReportMainItem nitemFaizVergiOncesiKarZarar { get; set; }
    public ReportMainItem nitemNetIsletmeSermaye { get; set; }
    public ReportMainItem nitemNetSatisBuyumeOran { get; set; }
    public ReportMainItem nitemCariOran { get; set; }
    public ReportMainItem nitemLikitideOran { get; set; }
    public ReportMainItem nitemNakitOran { get; set; }
    public ReportMainItem nitemAlacakDevir { get; set; }
    public ReportMainItem nitemTicariBorcDevir { get; set; }
    public ReportMainItem nitemStokDevir { get; set; }
    public ReportMainItem nitemBorcOzsermaye { get; set; }
    public ReportMainItem nitemTpolamBankaBorc { get; set; }
    public ReportMainItem nitemOzkaynakAktif { get; set; }
    public ReportMainItem nitemOzsermayeKarlilik { get; set; }
    public ReportMainItem nitemROAAktifKarlilik { get; set; }
}
