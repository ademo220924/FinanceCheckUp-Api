


namespace FinanceCheckUp.Application.Models.ViewModel;
public class DashBilancoViewCheckQnb
{
    public DashBilancoViewCheckQnb()
    {
        mrequestEntry = new List<DashBilancoViewQnb>();
        countet = 0;
    }
    public List<DashBilancoViewQnb> mrequestEntry { get; set; }
    public int countet { get; set; }

}
