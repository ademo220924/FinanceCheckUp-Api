namespace FinanceCheckUp.Application.Models
{
    public class DashYearlyResultMain
    {
        public string DocumentMonthTr { get; set; }
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public decimal Value { get; set; }
        public int SortVal { get; set; }
        public int TypeID { get; set; }
    }
}
