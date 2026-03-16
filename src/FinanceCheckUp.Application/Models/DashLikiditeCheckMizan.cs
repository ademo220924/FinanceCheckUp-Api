
namespace FinanceCheckUp.Application.Models;
public class DashLikiditeCheckMizan
{
    public DashLikiditeCheckMizan()
    {
        mrequestEntry = new List<DashBilancoViewMizan>();

    }
    public List<DashBilancoViewMizan> mrequestEntry { get; set; }
}