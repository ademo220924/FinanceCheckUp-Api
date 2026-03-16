using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers
{
    public interface IDashWCapitalViewMainManager : IGenericDapperRepository
    {
        public List<DashBilancoView> getList(int _year, long _compID);
    }


    public class DashWCapitalViewMainManager(FinanceCheckUpDbContext _dbContext, IDashWCapitalManager dashWCapitalManager) : GenericDapperRepositoryBase(_dbContext), IDashWCapitalViewMainManager
    {
        public List<DashBilancoView> getList(int _year, long _compID)
        {
            DashWCapitalCheck nCheck = new DashWCapitalCheck();

            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap1(_year, _compID), "Hazır Değerler", "A-Hazır Değerler");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap2(_year, _compID), "Menkul Kıymetler", "A1-Menkul Kıymetler");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap3(_year, _compID), "Ticari Alacaklar", "A2-Ticari Alacaklar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap4(_year, _compID), "Diğer Alacaklar", "A3-Diğer Alacaklar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcap5(_year, _compID), "Stoklar", "A4-Stoklar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapUc(_year, _compID), "İnşaat ve Onarım", "A4_- İnşaat ve Onarım");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapDort(_year, _compID), "Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapBes(_year, _compID), "Diğer Dönen Varlıklar", "A7-Diğer Dönen Varlıklar");

            ////////////////////////
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM1(_year, _compID), "Mali Borçlar", "C-Mali Borçlar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM2(_year, _compID), "Ticari Borçlar", "C1-Ticari Borçlar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM3(_year, _compID), "Diğer Çeşitli  Borçlar", "C2-Diğer Çeşitli  Borçlar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM4(_year, _compID), "Alınan Avanslar", "C3-Alınan Avanslar");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM5(_year, _compID), "Yıllara Yaygın İnşaat ve Onarım Hakedişleri", "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM6(_year, _compID), "Ödenencek Vergi ve Diğer Yükümlülükler", "C4-Ödenencek Vergi ve Diğer Yükümlülükler");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM7(_year, _compID), "Borç ve Gider Karşılıkları", "C5- Borç ve Gider Karşılıkları");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM8(_year, _compID), "Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları");
            nCheck.SetBilancoHeaderT(dashWCapitalManager.Get_getDataWcapM9(_year, _compID), "Diğer Kısa Vadeli Yabancı Kaynaklar", "C7-Diğer Kısa Vadeli Yabancı Kaynaklar");


            return nCheck.mrequestEntry;
        }
    }
}
