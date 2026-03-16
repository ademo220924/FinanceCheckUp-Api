using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.ViewModel;

namespace FinanceCheckUp.Application.Managers.StaticManagers;
public interface IDashBilancoViewMainQnbGelirManager
{
    List<DashBilancoViewQnb> getList(int _year, long _compID);
    List<DashBilancoViewQnb> getListA(int _year, long _compID);
    List<DashBilancoViewQnb> getListB(int _year, long _compID);
    List<DashBilancoViewQnb> getListC(int _year, long _compID);

    List<DashBilancoViewQnb> getListD(int _year, long _compID);
    List<DashBilancoViewQnb> getListE(int _year, long _compID);
    List<DashBilancoViewQnb> getListF(int _year, long _compID);
    List<DashBilancoViewQnb> getListG(int _year, long _compID);
    List<DashBilancoViewQnb> getListH(int _year, long _compID);
    List<DashBilancoViewQnb> getListI(int _year, long _compID);
    void setListSektor(int _year, long _compID);

}



public class DashBilancoViewMainQnbGelirManager(
    IDashBilancoViewCheckQnbManager dashBilancoViewCheckQnbManager,
    IDashBilancoSetQnbGelirManager dashBilancoSetQnbGelirManager,
    IDashBilancoSetQnbGelirAManager dashBilancoSetQnbGelirAManager,
    IDashBilancoSetQnbGelirBManager dashBilancoSetQnbGelirBManager,
    IDashBilancoSetQnbGelirCManager dashBilancoSetQnbGelirCManager,
    IDashBilancoSetQnbGelirDManager dashBilancoSetQnbGelirDManager,
    IDashBilancoSetQnbGelirEManager dashBilancoSetQnbGelirEManager,
    IDashBilancoSetQnbGelirFManager dashBilancoSetQnbGelirFManager,
    IDashBilancoSetQnbGelirGManager dashBilancoSetQnbGelirGManager,
    IDashBilancoSetQnbGelirHManager dashBilancoSetQnbGelirHManager,
    IDashBilancoSetQnbGelirIManager dashBilancoSetQnbGelirIManager) : IDashBilancoViewMainQnbGelirManager
{

    public List<DashBilancoViewQnb> getList(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirManager.Get_1(_year, _compID), "1.1", "Toplam Satış Gelirleri", 97, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirManager.Get_3(_year, _compID), "1.2", "Yurtiçi Satış Gelirleri", 99, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirManager.Get_5(_year, _compID), "1.3", "Yurtdışı Satış Gelirleri", 101, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirManager.Get_7(_year, _compID), "1.3.1", "Diğer Gelirler", 103, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirManager.Get_9(_year, _compID), "1.3.2", "Satış İadeleri(-)", 105, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirManager.Get_11(_year, _compID), "1.3.3", "Toplam Satış Maliyeti", 107, 1);

        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListA(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirAManager.Get_1(_year, _compID), "2.1", "Brüt Kar", 109, 1);


        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListB(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirBManager.Get_1(_year, _compID), "3.0", "Faaliyet Giderleri", 111, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirBManager.Get_3(_year, _compID), "4.1", "Esas Faaliyet Karı (Zararı)", 113, 1);

        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListC(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirCManager.Get_1(_year, _compID), "4.1", "Finansman Gideri", 115, 1);

        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListD(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirDManager.Get_1(_year, _compID), "5.1", "Kambiyo Karı (Zararı)", 117, 1);


        return nCheck.mrequestEntry;
    }

    public List<DashBilancoViewQnb> getListE(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirEManager.Get_1(_year, _compID), "5.1", "Toplam Diğer Faaliyetlerden Olağan Gelir / Gider", 119, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirEManager.Get_3(_year, _compID), "5.2", "Diğer Faaliyetlerden Olağan Gelir Ve Karlar", 121, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirEManager.Get_5(_year, _compID), "5.3", "Diğer Faaliyetlerden Olağan Gider Ve Zararlar(-)", 123, 1);

        return nCheck.mrequestEntry;
    }

    public List<DashBilancoViewQnb> getListF(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirFManager.Get_1(_year, _compID), "4.1", "Vergi Öncesi Kar (Zarar)", 125, 1);

        return nCheck.mrequestEntry;
    }
    //
    public List<DashBilancoViewQnb> getListG(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirGManager.Get_1(_year, _compID), "4.1", "Toplam Olağandışı Gelir Ve Karlar /Gider Ve Zararlar ", 127, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirGManager.Get_3(_year, _compID), "4.1", "Olağandışı Gelir Ve Karlar", 129, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirGManager.Get_5(_year, _compID), "4.1", "Olağandışı Gider Ve Zararlar (-) ", 131, 1);
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirGManager.Get_7(_year, _compID), "4.1", "Dönem Karı Vergi Ve Diğ.Yasal Yükümlülük Karşılığı", 132, 1);
        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListH(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirHManager.Get_1(_year, _compID), "4.1", "Dönem Karı (Zararı)", 133, 1);

        return nCheck.mrequestEntry;
    }
    public List<DashBilancoViewQnb> getListI(int _year, long _compID)
    {
        DashBilancoViewCheckQnb nCheck = new DashBilancoViewCheckQnb();
        nCheck = dashBilancoViewCheckQnbManager.SetBilancoHeaderT(nCheck, dashBilancoSetQnbGelirIManager.Get_1(_year, _compID), "4.1", "FAVÖK (EBITDA)", 135, 1);

        return nCheck.mrequestEntry;
    }

    public void setListSektor(int _year, long _compID)
    {
        dashBilancoSetQnbGelirIManager.SetSektor(_year, _compID);
    }

}