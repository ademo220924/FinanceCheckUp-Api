
namespace FinanceCheckUp.Application.Models.ViewModel;
public class ReadPdfMizan
{

    public string AmountBakiye { get; set; }
    public string CreditAmount { get; set; }
    public string DebitAmount { get; set; }
    public string AccountMainDescription { get; set; }
    public string AccountMainID { get; set; }
    public int CounterNo { get; set; }
    public string LineContent { get; set; }
    public byte IsRevenue { get; set; }

}