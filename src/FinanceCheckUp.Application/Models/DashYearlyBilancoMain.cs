namespace FinanceCheckUp.Application.Models
{
    public class DashYearlyBilancoMain
    {
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public double Value { get; set; }
        public int SortVal { get; set; }
        public int TypeID { get; set; }
        public int CounterZone { get; set; }
        public string GroupName { get; set; }
    }
}
