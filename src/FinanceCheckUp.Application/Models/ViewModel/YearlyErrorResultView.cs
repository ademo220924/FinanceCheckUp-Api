namespace FinanceCheckUp.Application.Models.ViewModel
{
    public class YearlyErrorResultView
    {

        public IEnumerable<YearlyErrorResult> mrequestEntryCount { get; set; }
        public string EntryCountTotal => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Sum(x => x.TRowCount).ToString("N0") : "0";

        public string ErrorCountTotal => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Sum(x => x.TErrorRowCount).ToString("N0") : "0";
        public string EntryCountLast => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth == mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TRowCount).ToString() : "0";
        public string ErrorCountLast => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth == mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TErrorRowCount).ToString() : "0";
        public string EntryCountBefore => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth != mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TRowCount).ToString() : "0";
        public string ErrorCountBefore => mrequestEntryCount.Sum(x => x.TRowCount) > 0 ? mrequestEntryCount.Where(x => x.MainMonth != mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth)).Sum(x => x.TErrorRowCount).ToString() : "0";
    }
}
