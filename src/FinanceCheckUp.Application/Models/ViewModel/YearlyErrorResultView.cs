namespace FinanceCheckUp.Application.Models.ViewModel
{
    public class YearlyErrorResultView
    {

        public IEnumerable<YearlyErrorResult>? mrequestEntryCount { get; set; }

        public string EntryCountTotal => mrequestEntryCount != null
            ? mrequestEntryCount.Sum(x => x.TRowCount) > 0
                ? mrequestEntryCount.Sum(x => x.TRowCount).ToString("N0")
                : "0"
            : "0";

        public string ErrorCountTotal => mrequestEntryCount != null
            ? mrequestEntryCount.Sum(x => x.TRowCount) > 0
                ? mrequestEntryCount.Sum(x => x.TErrorRowCount).ToString("N0")
                : "0"
            : "0";

        public string EntryCountLast => mrequestEntryCount != null
            ? mrequestEntryCount.Sum(x => x.TRowCount) > 0
                ? mrequestEntryCount
                    .Where(x => x.MainMonth == mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth))
                    .Sum(x => x.TRowCount).ToString()
                : "0"
            : "0";

        public string ErrorCountLast => mrequestEntryCount != null
            ? mrequestEntryCount.Sum(x => x.TRowCount) > 0
                ? mrequestEntryCount
                    .Where(x => x.MainMonth == mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth))
                    .Sum(x => x.TErrorRowCount).ToString()
                : "0"
            : "0";

        public string EntryCountBefore => mrequestEntryCount != null
            ? mrequestEntryCount.Sum(x => x.TRowCount) > 0
                ? mrequestEntryCount
                    .Where(x => x.MainMonth != mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth))
                    .Sum(x => x.TRowCount).ToString()
                : "0"
            : "0";

        public string ErrorCountBefore => mrequestEntryCount != null
            ? mrequestEntryCount.Sum(x => x.TRowCount) > 0
                ? mrequestEntryCount
                    .Where(x => x.MainMonth != mrequestEntryCount.Where(x => x.TRowCount > 0).Max(x => x.MainMonth))
                    .Sum(x => x.TErrorRowCount).ToString()
                : "0"
            : "0";
    }
}
