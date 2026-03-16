
namespace FinanceCheckUp.Application.Models.Common
{
    public class DataViewerMain
    {
        public DataViewerMain()
        {
            EntryData = new List<DataViewer>();

        }

        public List<DataViewer> EntryData { get; set; }

        public int EntryCombinCount => EntryData.Select(c => c.EntryNumber).Distinct().Count();

        public string EntryCombineLast => EntryCombinCount > 0 ? EntryData.Where(x => x.EndDate.Month == EntryData.Max(x => x.EndDate.Month)).Select(c => c.EntryNumber).Distinct().Count().ToString() : "0";
        public string EntryCombineBefore => EntryCombinCount > 0 ? EntryData.Where(x => x.EndDate.Month != EntryData.Max(x => x.EndDate.Month)).Select(c => c.EntryNumber).Distinct().Count().ToString() : "0";

        public void SetDataViewer(List<DataViewer> requestEntryCount)
        {

            var nDash = new DataViewer();

            EntryData = requestEntryCount.Select(x => new DataViewer
            {
                GroupName = x.EntryNumber.ToString() + " Entry No",
                AccountMainDescription = x.AccountMainDescription,
                AccountMainID = x.AccountMainID,
                AccountSubDescription = x.AccountSubDescription,
                AccountSubID = x.AccountSubID,
                Amount = x.Amount,
                DetailComment = x.DetailComment,
                DebitCreditCode = x.DebitCreditCode,
                DocumentDate = x.DocumentDate,
                DocumentTypeDescription = x.DocumentTypeDescription,
                EnteredBy = x.EnteredBy,
                EntryNumber = x.EntryNumber,
                PaymentMethod = x.PaymentMethod,
                EndDate = x.EndDate,
                ColorDesc = x.ColorDesc,
                Description = x.Description,
                ColorDescTax = x.ColorDescTax,
                DescriptionTax = x.DescriptionTax,
                ColorDescInside = x.ColorDescInside,
                DescriptionInside = x.DescriptionInside,
            }).ToList();
        }
    }
}
