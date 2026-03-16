using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashLikiditeViewMainMizanManager
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID);
}


public class DashLikiditeViewMainMizanManager(
    IDashLikiditeCheckMizanManager dashLikiditeCheckMizanManager,
    IDashBilancoSetMizanManager dashBilancoSetMizanManager,
    IDashWCapitalMizanManager dashWCapitalMizanManager
) : IDashLikiditeViewMainMizanManager
{

    public List<DashBilancoViewMizan> getList(int _year, long _compID)
    {
        DashLikiditeCheckMizan nCheck = new DashLikiditeCheckMizan();

        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap1(_year, _compID), "A-Hazır Değerler", "A-Hazır Değerler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap2(_year, _compID), "A1-Menkul Kıymetler", "A1-Menkul Kıymetler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap3(_year, _compID), "A2-Ticari Alacaklar", "A2-Ticari Alacaklar");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap4(_year, _compID), "A3-Diğer Alacaklar", "A3-Diğer Alacaklar");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", "Kısa vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_AlinanAvansUT(_year, _compID), "D4-Maddi Duran Varlıklar", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", "Uzun vadeli yükümlülükler");
        dashLikiditeCheckMizanManager.SetBilancoHeaderT(nCheck, dashBilancoSetMizanManager.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", "Uzun vadeli yükümlülükler");
        return nCheck.mrequestEntry;
    }

}