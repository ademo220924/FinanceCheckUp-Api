namespace FinanceCheckUp.Application.Models
{
    public class DashBilancoViewMznShort
    {
        public string AccountMainID { get; set; }
        public string AccountMainIDTxt
        {
            get
            {
                return AccountMainID + " - " + AccountMainDescription;
            }
        }
        public string AccountMainDescription { get; set; }
        public long SmmBefore { get; set; }
        public long SmmAfter { get; set; }
        public long AktarmaOnce => SmmBefore;
        public long AktarmaSonra => SmmAfter;
        public long Diff { get; set; }
        public long CompanyID { get; set; }
        public int IsHidden { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
    }
}
