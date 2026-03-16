using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Managers.StaticManagers
{
    public interface IDashLikiditeViewMainManager
    {
        public List<DashBilancoView> getList(int _year, long _compID);
    }

    public class DashLikiditeViewMainManager(IDashWCapitalManager dashWCapitalManager, IDashGelirTablosuManager dashGelirTablosuManager) : IDashLikiditeViewMainManager
    {
        public List<DashBilancoView> getList(int _year, long _compID)
        {
            DashLikiditeCheck nCheck = new DashLikiditeCheck();

            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap1(_year, _compID), "A-Hazır Değerler", "A-Hazır Değerler");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap2(_year, _compID), "A1-Menkul Kıymetler", "A1-Menkul Kıymetler");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap3(_year, _compID), "A2-Ticari Alacaklar", "A2-Ticari Alacaklar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap4(_year, _compID), "A3-Diğer Alacaklar", "A3-Diğer Alacaklar");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVBorc(_year, _compID), "Kısa Vadeli Borçlanmalar", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVUznVdBorcKisaVadKrslk(_year, _compID), "Uzun Vadeli Borçlanmaların Kısa Vadeli Kısımları", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVDigrFinsYukmlk(_year, _compID), "Diğer Finansal Yükümlülükler", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVTicBorc(_year, _compID), "Ticari Borçlar", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVOdenckVergi(_year, _compID), "Ödenecek Vergi Ve Diğer Yükümlülükler", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVDigerBorclar(_year, _compID), "Diğer Borçlar ", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVErtlnmsGelirler(_year, _compID), "Ertelenmiş gelirler", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVonemKarVergiYukmluluk(_year, _compID), "Dönem Karı Vergi Yükümlülüğü", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVKisaVadeKarsilik(_year, _compID), "Kısa vadeli Karşılıklar", "Kısa vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKVDigrKVadeYukmluluk(_year, _compID), "Diğer Kısa Vadeli Yükümlülükler", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeKisaVadeToplamT(_year, _compID), "Toplam kısa vadeli yükümlülükler", "Kısa vadeli yükümlülükler");

            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVUzunVadeBorc(_year, _compID), "Uzun vadeli borçlanmalar", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVDigFinansYukmlulk(_year, _compID), "Diğer Finansal Yükümlülükler (UV)", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVTicBorc(_year, _compID), "Ticari Borçlar (UV)", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVDigBorc(_year, _compID), "Diğer Borçlar (UV)", "Uzun vadeli yükümlülükler");


            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVErtlenemisGelir(_year, _compID), "Ertelenmiş Gelirler (UV)", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVadeKarsilik(_year, _compID), "Uzun Vadeli Karşılıklar", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVErtlVergiYukmlulk(_year, _compID), "Ertelenmiş Vergi Yükümlülüğü", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUVDigerUzVadYukumlk(_year, _compID), "Diğer Uzun Vadeli Yükümlülükler", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeUzunVadeToplamT(_year, _compID), "Toplam uzun vadeli yükümlülükler", "Uzun vadeli yükümlülükler");
            //nCheck.SetBilancoHeaderT(DashLikidite.Get_MBLikiditeTUMToplamT(_year, _compID), "Yükümlülükler toplamı", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", "Kısa vadeli yükümlülükler");


            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", "Kısa vadeli yükümlülükler");


            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", "Kısa vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "Kısa vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", "Kısa vadeli yükümlülükler");
            // - 
            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", "Kısa vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_AlinanAvansUT(_year, _compID), "D4-Maddi Duran Varlıklar", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", "Uzun vadeli yükümlülükler");

            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", "Uzun vadeli yükümlülükler");
            nCheck.SetBilancoHeaderT(dashGelirTablosuManager.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", "Uzun vadeli yükümlülükler");
            return nCheck.mrequestEntry;
        }

    }
}
