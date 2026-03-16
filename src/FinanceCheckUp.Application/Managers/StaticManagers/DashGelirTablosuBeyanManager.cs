using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Managers.StaticManagers;
public interface IDashGelirTablosuBeyanManager
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID);
}


public class DashGelirTablosuBeyanManager(
    IDashGelirTablosuViewTManager dashGelirTablosuViewTManager,
    IDashGelirTablosuSetManager dashGelirTablosuSetManager) : IDashGelirTablosuBeyanManager
{
    public List<DashBilancoViewMizan> getList(int _year, long _compID)
    {
        DashGelirTablosuViewT nCheck = new DashGelirTablosuViewT();
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_BrutStsT(_year, _compID), "A-Brüt Satışlar", 60, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_BrutSts(_year, _compID), "A-Brüt Satışlar", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_StsIndirimT(_year, _compID), "B-Satış Indirimleri(-)", 61, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_StsIndirim(_year, _compID), "B-Satış Indirimleri(-)", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_NetStsT(_year, _compID), "C-Net Satışlar", 111, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_StsMlytT(_year, _compID), "D-Satışların Maliyeti (-)", 62, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_StsMlyt(_year, _compID), "D-Satışların Maliyeti (-)", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_BrutKarZararT(_year, _compID), "E-Brüt Kar/Zararı", 222, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_ESMMGenel(_year, _compID), "E-SMM Satışların Maliyeti (Mizanda 7'li Gruplarda Bekleyen)", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_GenelYonGiderT(_year, _compID), "F-Genel Yönetim Giderleri (-)", 333, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_PazarlamaGiderT(_year, _compID), "G-Pazarlama Giderleri (-)", 444, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_ArGeGiderT(_year, _compID), "H-Araştırma ve Geliştirme Giderleri (-)", 555, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_EsasMaliyetKarZararT(_year, _compID), "J-Esas Faaliyet Karı/Zararı", 888, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_DigerFalGelT(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 999, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_DigerFalGel(_year, _compID), "K-DİĞER FAALİYETLERDEN OLAĞAN GELİR VE KARLAR", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_DigerFalGidrT(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 1111, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_DigerFalGidr(_year, _compID), "L-DİĞER FAALİYETLERDEN OLAĞAN GİDER VE ZARARLAR", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_FaaliyetKarZaraT(_year, _compID), "M-FİNANSMAN GİDERİ ÖNCESİ FAALİYET KARI ZARARI", 2222, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_FinansmanGidrT(_year, _compID), "N-Finansman Giderleri", 3333, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_OlaganKarZaraT(_year, _compID), "O-OLAĞAN KAR VEYA  ZARAR", 4444, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_OlaganDisiGelrT(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 5555, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_OlaganDisiGelr(_year, _compID), "V-OLAĞANDIŞI GELIR VE KARLAR", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_OlaganDisiGdrT(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 7777, 1);
        nCheck = dashGelirTablosuViewTManager.SetBilanco(nCheck, dashGelirTablosuSetManager.Get_OlaganDisiGdr(_year, _compID), "Y-OLAĞANDIŞI GİDER VE ZARARLAR", 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_DonemKarZaraT(_year, _compID), "Z-DÖNEM KARI/ZARARI", 9991, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_OlaganDisiGdrYkmllk(_year, _compID), "Z1-DÖNEM KARI VERGİ VE DİĞ.YASAL YÜKÜMLÜLÜK KARŞILIĞI", 9993, 0);
        nCheck = dashGelirTablosuViewTManager.SetBilancoHeaderT(nCheck, dashGelirTablosuSetManager.Get_DonemKarZaraTNet(_year, _compID), "ZT-DÖNEM NET KARI/ZARARI", 9995, 0);

        return nCheck.mrequestEntryMizan;
    }

}