using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashBilancoBeyanManager : IGenericDapperRepository
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID);
}

public class DashBilancoBeyanManager(
    FinanceCheckUpDbContext _dbContext,
    IDashBilancoViewMizanCheckManager dashBilancoViewMizanCheckManager,
    IDashBilancoSetBeyanManager dashBilancoSetBeyanManager) : GenericDapperRepositoryBase(_dbContext), IDashBilancoBeyanManager
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID)
    {
        DashBilancoViewMizanCheck nCheck = new DashBilancoViewMizanCheck();

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_Stok(_year, _compID), "A4-Stoklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAMAktif(_year, _compID), "BTT- TOPLAM AKTİFLER", 2221, 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
        // -
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
        nCheck = dashBilancoViewMizanCheckManager.SetBilanco(nCheck, dashBilancoSetBeyanManager.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

        ///

        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAMOzKaynakUT(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);
        nCheck = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheck, dashBilancoSetBeyanManager.Get_TOPLAMPasifByn(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);

        //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);





        return nCheck.mrequestEntry;
    }

}