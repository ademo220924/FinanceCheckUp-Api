
namespace FinanceCheckUp.Application.Models.ViewModel;
public class YearlyErrorResult
{
    public int MainYear { get; set; }
    public int MainMonth { get; set; }
    public int TErrorRowCount { get; set; }
    public string DocumentMonth { get; set; }
    public string DocumentMonthTr { get; set; }
    public int TRowCount { get; set; }
    public int TNonErrorRowCount { get; set; }
    public string TxResult { get; set; }
}