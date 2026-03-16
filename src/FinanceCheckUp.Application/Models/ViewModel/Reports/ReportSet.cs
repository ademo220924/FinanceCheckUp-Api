namespace FinanceCheckUp.Application.Models.ViewModel.Reports;

public class ReportSet
{
    public int TypeID { get; set; }
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public string AccountSubDescription { get; set; }

    public string AccountMainEng { get; set; }
    public long Amount { get; set; }
    public long BorcBakiye { get; set; }
    public long AlacakBakiye { get; set; }
    public long AmountMzn { get; set; }
    public long MainAmountTotal { get; set; }
    public long MainAmountTotalMzn { get; set; }
    public string DebitCreditCode { get; set; }
    public long AmountBakiye { get; set; }
    public long AmountBakiyeMzn { get; set; }
    public long Debit { get; set; }
    public long Credit { get; set; }
    public int SubTypeID { get; set; }
    public int Year { get; set; }
    public int MainTypeID { get; set; }
    public bool IsErrored { get; set; }
}