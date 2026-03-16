
namespace FinanceCheckUp.Application.Models;
public class Data
{
    public long ID { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string EnteredBy { get; set; }
    public string EnteredDate { get; set; }
    public string EntryNumber { get; set; }
    public string EntryComment { get; set; }
    public string BatchID { get; set; }
    public string BatchDescription { get; set; }
    public float TotalDebit { get; set; }
    public float TotalCredit { get; set; }
    public string DocumentType { get; set; }
    public string DocumentTypeDescription { get; set; }
    public string DocumentNumber { get; set; }
    public string DocumentDate { get; set; }
    public string PaymentMethod { get; set; }
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public string AccountSubDescription { get; set; }
    public string AccountSubID { get; set; }
    public float Amount { get; set; }
    public string DebitCreditCode { get; set; }
    public string PostingDate { get; set; }
    public string DetailComment { get; set; }
    public long CsvID { get; set; }
    public bool IsFailed { get; set; }
    public bool IsOpener { get; set; }
    public int IsPassedEntry { get; set; }
}