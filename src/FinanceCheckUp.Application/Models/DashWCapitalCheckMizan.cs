
namespace FinanceCheckUp.Application.Models;
public class DashWCapitalCheckMizan
{
    public DashWCapitalCheckMizan()
    {
        mrequestEntry = new List<DashBilancoViewMizan>();

    }
    public List<DashBilancoViewMizan> mrequestEntry { get; set; }

}