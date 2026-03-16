
namespace FinanceCheckUp.Application.Models;
public class DashGelirTablosuViewT
{
    public DashGelirTablosuViewT()
    {
        mrequestEntryMizan = new List<DashBilancoViewMizan>();
        mrequestEntry = new List<DashBilancoView>();
        counter = 0;
    }
    public List<DashBilancoViewMizan> mrequestEntryMizan { get; set; }
    public int counter { get; set; }
    public List<DashBilancoView> mrequestEntry { get; set; }
}

