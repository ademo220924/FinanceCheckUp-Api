using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;
public interface IDashWCapitalViewMainMizanManager : IGenericDapperRepository
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID);
}


public class DashWCapitalViewMainMizanManager(
    FinanceCheckUpDbContext _dbContext,
    IDashWCapitalCheckMizanManager dashWCapitalCheckMizanManager,
    IDashWCapitalMizanManager dashWCapitalMizanManager) : GenericDapperRepositoryBase(_dbContext), IDashWCapitalViewMainMizanManager
{

    public List<DashBilancoViewMizan> getList(int _year, long _compID)
    {
        DashWCapitalCheckMizan nCheck = new DashWCapitalCheckMizan();

        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap1(_year, _compID), "Hazır Değerler", "A-Hazır Değerler");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap2(_year, _compID), "Menkul Kıymetler", "A1-Menkul Kıymetler");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap3(_year, _compID), "Ticari Alacaklar", "A2-Ticari Alacaklar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap4(_year, _compID), "Diğer Alacaklar", "A3-Diğer Alacaklar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcap5(_year, _compID), "Stoklar", "A4-Stoklar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapUc(_year, _compID), "İnşaat ve Onarım", "A4_- İnşaat ve Onarım");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapDort(_year, _compID), "Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapBes(_year, _compID), "Diğer Dönen Varlıklar", "A7-Diğer Dönen Varlıklar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM1(_year, _compID), "Mali Borçlar", "C-Mali Borçlar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM2(_year, _compID), "Ticari Borçlar", "C1-Ticari Borçlar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM3(_year, _compID), "Diğer Çeşitli  Borçlar", "C2-Diğer Çeşitli  Borçlar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM4(_year, _compID), "Alınan Avanslar", "C3-Alınan Avanslar");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM5(_year, _compID), "Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM6(_year, _compID), "Ödenencek Vergi ve Diğer Yükümlülükler", "C4-Ödenencek Vergi ve Diğer Yükümlülükler");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM7(_year, _compID), "Borç ve Gider Karşılıkları", "C5- Borç ve Gider Karşılıkları");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM8(_year, _compID), "Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları");
        nCheck = dashWCapitalCheckMizanManager.SetBilancoHeaderT(nCheck, dashWCapitalMizanManager.Get_getDataWcapM9(_year, _compID), "Diğer Kısa Vadeli Yabancı Kaynaklar", "C7-Diğer Kısa Vadeli Yabancı Kaynaklar");


        return nCheck.mrequestEntry;
    }
}