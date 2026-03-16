namespace FinanceCheckUp.Application.Models
{
    public class TaxErrorCheck
    {
        public TaxErrorCheck()
        {
            taxchecklist = new List<TaxErrorCheck>();
        }
        public long ID { get; set; }
        public string EnteredDate { get; set; }
        public string EntryNumber { get; set; }
        public string EntryComment { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubDescription { get; set; }
        public string AccountSubID { get; set; }
        public float Amount { get; set; }
        public string DebitCreditCode { get; set; }
        public string DocumentDate { get; set; }
        public string DetailComment { get; set; }
        public long CsvID { get; set; }
        public DateTime PostingDate_ => Convert.ToDateTime(DocumentDate);
        public int Day => PostingDate_.Day;
        public int Month => PostingDate_.Month;
        public int Year => PostingDate_.Year;
        public int ErrorIdentity { get; set; }
        public List<TaxErrorCheck> taxchecklist { get; set; }

        public void checklist(List<Data> chklist)
        {

            taxchecklist = chklist.Select(x => new TaxErrorCheck()
            {
                ID = x.ID,
                EnteredDate = x.EnteredDate,
                EntryNumber = x.EntryNumber,
                CsvID = x.CsvID,
                DetailComment = x.DetailComment,
                DocumentDate = x.DocumentDate,
                DebitCreditCode = x.DebitCreditCode,
                Amount = x.Amount,
                AccountSubID = x.AccountSubID,
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                AccountSubDescription = x.AccountSubDescription,
                EntryComment = x.EntryComment

            }).ToList();
        }

    }
}
