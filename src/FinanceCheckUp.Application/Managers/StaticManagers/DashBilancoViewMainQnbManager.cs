using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;
public interface IDashBilancoViewMainQnbManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> getList(int _year, long _compID);
    List<DashBilancoViewQnb> getListToplam(int _year, long _compID);
    List<DashBilancoViewQnb> getListA(int _year, long _compID);
    List<DashBilancoViewQnb> getListAToplam(int _year, long _compID);
    List<DashBilancoViewQnb> getListB(int _year, long _compID);
    List<DashBilancoViewQnb> getListBToplam(int _year, long _compID);
    List<DashBilancoViewQnb> getListC(int _year, long _compID);
    List<DashBilancoViewQnb> getListCToplam(int _year, long _compID);
    List<DashBilancoViewQnb> getListD(int _year, long _compID);
    List<DashBilancoViewQnb> getListDToplam(int _year, long _compID);

}



public class DashBilancoViewMainQnbManager(
    FinanceCheckUpDbContext _dbContext,
    IDashBilancoViewCheckQnbManager dashBilancoViewCheckQnbManager,
    IDashBilancoSetQnbSqlOperationManager dashBilancoSetQnbSqlOperationManager,
    IDashBilancoSetQnbASqlOperationManager dashBilancoSetQnbASqlOperationManager,
    IDashBilancoSetQnbBSqlOperationManager dashBilancoSetQnbBSqlOperationManager,
    IDashBilancoSetQnbCSqlOperationManager dashBilancoSetQnbCSqlOperationManager,
    IDashBilancoSetQnbDSqlOperationManager dashBilancoSetQnbDSqlOperationManager
) : GenericDapperRepositoryBase(_dbContext), IDashBilancoViewMainQnbManager
{


    public List<DashBilancoViewQnb> getList(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();

        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_HazirDegerT(_year, _compID), "1.1", "Hazır Değerler", 1, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_MenkulKiymetT(_year, _compID), "1.2", "Menkul Kıymetler", 3, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_TicariAlacakT(_year, _compID), "1.3", "Ticari Alacaklar", 5, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_AlicilarT(_year, _compID), "1.3.1", "Alıcılar", 7, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_AlinanCeklerT(_year, _compID), "1.3.2", "Alınan Çekler", 9, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_SupheliTicariT(_year, _compID), "1.3.3", "Şüpheli Ticari Alacaklar Karşılığı (-)", 11, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_StoklarT(_year, _compID), "1.4", "Stoklar", 13, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_HammaddeT(_year, _compID), "1.4.1", "Hammadde ve Malzeme", 15, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_YariMamulT(_year, _compID), "1.4.2", "Yarımamul ve Mamuller", 17, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_TicariMalT(_year, _compID), "1.4.3", "Ticari Mallar", 19, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_VerilenSiparisT(_year, _compID), "1.4.4", "Verilen Sipariş  Avansları", 21, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_insaatT(_year, _compID), "1.5", "İnşaat ve Onarım ", 23, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_OrtakalacakT(_year, _compID), "1.6", "Ortaklardan Alacaklar  / Bağlı Ortaklıklar ", 25, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_DigerAlacakT(_year, _compID), "1.7", "Diğer Alacaklar ", 27, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_GelecekAyT(_year, _compID), "1.8", "Gelecek Aylara ait Giderler ve Gelir Tahakkukları", 29, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_DigerDonenT(_year, _compID), "1.9", "Toplam Diğer Dönen Varlıklar", 31, 1);
        return nCheck.mrequestEntry;
    }

    public List<DashBilancoViewQnb> getListToplam(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbSqlOperationManager.Get_Toplam(_year, _compID), string.Empty, "Toplam Dönen Varlıklar", 311, 1);
        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListA(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_1(_year, _compID), "2.1", "Net Maddi Duran Varlıklar", 33, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_2(_year, _compID), "2.2", "Net Maddi Olmayan Varlıklar", 35, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_3(_year, _compID), "2.3", "İştirak ve Bağlı ortaklıklar/Ortaklardan Alacaklar", 37, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_4(_year, _compID), "2.4", "Ticari Alacaklar", 39, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_5(_year, _compID), "2.5", "Diğer Alacaklar ", 41, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_6(_year, _compID), "2.6", "Diğer Bağlı Kıymetler", 43, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_7(_year, _compID), "2.7", "Özel Tükenmeye Tabi Varlıklar", 45, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_8(_year, _compID), "2.8", "Diğer Duran Varlıklar ", 47, 1);
        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListAToplam(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_Toplam(_year, _compID), string.Empty, "Toplam Duran Varlıklar", 471, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbASqlOperationManager.Get_ToplamA(_year, _compID), string.Empty, "Toplam Varlıklar", 473, 1);

        return nCheck.mrequestEntry;
    }

    public List<DashBilancoViewQnb> getListB(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_1(_year, _compID), "3.0", "Kısa Vadeli Mali Borçlar", 49, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_2(_year, _compID), "3.1", "Uzun Vadeli Borç Cari Yıl Taksidi", 51, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_3(_year, _compID), "3.2", "Ticari Boçlar", 53, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_4(_year, _compID), "3.2.1", "Senetli Borçlar", 55, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_5(_year, _compID), "3.2.2", "Ticari Borçlar", 57, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_6(_year, _compID), "3.3", "Ortaklara ve Bağlı Şirketlere Borçlar", 59, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_7(_year, _compID), "3.3", "Diğer Borçlar", 61, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_8(_year, _compID), "3.4", "Alınan Sipariş Avansları", 63, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_9(_year, _compID), "3.5", "Yıllara Yaygın İnşat ve Onarım Hakedişleri", 65, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_10(_year, _compID), "3.6", "Ödenecek Vergiler", 67, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_11(_year, _compID), "3.7", "Borç ve Gider Karşılıkları", 69, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_12(_year, _compID), "3.8", "Gelecek Ayllara Ait Gelir ve Gider Tahakkukları", 71, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_13(_year, _compID), "3.9", "Diğer Kısa Vadeli Borçlar", 711, 1);
        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListBToplam(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbBSqlOperationManager.Get_Toplam(_year, _compID), string.Empty, "Toplam Kısa Vadeli Borçlar", 713, 1);


        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListC(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_1(_year, _compID), "4.1", "Uzun Vadeli Mali Borçlar", 73, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_2(_year, _compID), "4.2", "Ticari Borçlar ", 75, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_3(_year, _compID), "4.3", "Ortaklara ve Bağlı Şirketlere  Borçlar", 77, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_4(_year, _compID), "4.4", "Diğer Borçlar", 79, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_5(_year, _compID), "4.5", "Alınan Sipariş Avansları", 81, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_6(_year, _compID), "4.6", "Borç ve Gider Karşılıkları ", 83, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_7(_year, _compID), "4.7", "Toplam Diğer Uzun Vadeli Borçlar", 85, 1);
        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListCToplam(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbCSqlOperationManager.Get_Toplam(_year, _compID), string.Empty, "Toplam Uzun Vadeli Borçlar", 851, 1);

        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListD(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_1(_year, _compID), "5.1", "Ödenmiş Sermaye", 87, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_2(_year, _compID), "5.2", "İhtiyatlar ve Yedekler", 89, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_3(_year, _compID), "5.3", "Özel Fonlar", 91, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_4(_year, _compID), "5.4", "Geçmiş Yıl Karları / Zararları", 93, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_5(_year, _compID), "5.5", "Dönem Karı / Zararı", 95, 1);
        return nCheck.mrequestEntry;
    }

    public List<DashBilancoViewQnb> getListDToplam(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_Toplam(_year, _compID), string.Empty, "Toplam Özkaynaklar", 951, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_ToplamA(_year, _compID), string.Empty, "Toplam Borçlar", 953, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbDSqlOperationManager.Get_ToplamB(_year, _compID), string.Empty, "Toplam Borç ve Özkaynak", 955, 1);
        return nCheck.mrequestEntry;
    }

}