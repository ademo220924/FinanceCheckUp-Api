using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models
{
    public class TaxErrorcheckDataz
    {

        public TaxErrorcheckDataz()
        {
            taxchecklist = new List<TaxErrorcheckDataz>();
        }

        public long CsvID { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string AccountSubID { get; set; }
        public string AccountSubDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public float Amount { get; set; }
        public int ErrorIdentity { get; set; }


        public void checklist(List<TblxmlsourceMain> chklist)
        {

            taxchecklist = chklist.Select(x => new TaxErrorcheckDataz()
            {
                CsvID = (long)x.CsvId,
                DebitCreditCode = x.DebitCreditCode,
                Amount = (float)x.Amount,
                EndDate = (DateTime)x.EndDate,
                AccountSubID = x.AccountSubID,
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                AccountSubDescription = x.AccountSubDescription

            }).ToList();
        }
        public List<TaxErrorcheckDataz> taxchecklist { get; set; }
    }
}
