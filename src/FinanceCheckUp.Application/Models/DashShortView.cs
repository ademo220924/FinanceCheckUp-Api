namespace FinanceCheckUp.Application.Models
{
    public class DashShortView
    {
        public int AccountMainID { get; set; }

        public string AccountMainDescription { get; set; }
        public decimal Amount { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int TypeID { get; set; }
    }
}
