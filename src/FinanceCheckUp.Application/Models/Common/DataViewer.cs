namespace FinanceCheckUp.Application.Models.Common
{
    public class DataViewer
    {
        public string EntryNumber { get; set; }
        public string DocumentDate { get; set; }
        public string EnteredBy { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public float Amount { get; set; }
        public string DetailComment { get; set; }
        public string PaymentMethod { get; set; }
        public string DocumentTypeDescription { get; set; }
        public string GroupName { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int ColorDesc { get; set; }
        public string DescriptionTax { get; set; }
        public int ColorDescTax { get; set; }
        public string DescriptionInside { get; set; }
        public int ColorDescInside { get; set; }
    }
}
