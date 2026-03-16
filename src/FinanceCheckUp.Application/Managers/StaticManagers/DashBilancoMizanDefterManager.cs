using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashBilancoMizanDefterManager : IGenericDapperRepository
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID);
}


public class DashBilancoMizanDefterManager(
    FinanceCheckUpDbContext _dbContext,
IDashBilancoViewMizanCheckManager dashBilancoViewMizanCheckManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager) : GenericDapperRepositoryBase(_dbContext), IDashBilancoMizanDefterManager
{

    public List<DashBilancoViewMizan> getList(int _year, long _compID)
    {
        DashBilancoViewMizanCheck nCheckdefter = new DashBilancoViewMizanCheck();
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_Stok(_year, _compID), "A4-Stoklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
        // -
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilanco(nCheckdefter, dashBilancoSetMizanManager.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

        ///

        nCheckdefter = dashBilancoViewMizanCheckManager.SetBilancoHeaderT(nCheckdefter, dashBilancoSetMizanManager.Get_TOPLAMOzKaynakUTV3(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);

        //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);





        return nCheckdefter.mrequestEntry;
    }

}