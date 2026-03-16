namespace FinanceCheckUp.Application.Models
{
    public class YearlyUploadResult
    {
        public int MainYear { get; set; }
        public int MainMonth { get; set; }
        public long CsvID { get; set; }
        public int ErrorCount { get; set; }
        public string DocumentMonth { get; set; }
        public string DocumentMonthTr { get; set; }
        public string TxResult { get; set; }
        public string XmlDocName { get; set; }
    }
}
