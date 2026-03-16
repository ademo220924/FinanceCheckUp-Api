namespace FinanceCheckUp.Application.Models
{
    public class DashPivotView
    {
        public string AccountMainID { get; set; }

        public string AccountMainDescription { get; set; }
        public decimal Amount { get; set; }
        public decimal Diff { get; set; }
        public string DiffTx => "% " + this.Diff.ToString("0.00");
        public string DiffZone { get; set; }
        public decimal DiffVal { get; set; }
        public long CompanyID { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
        public byte IsHidden { get; set; }
        public string YearTx { get; set; }
    }
}
