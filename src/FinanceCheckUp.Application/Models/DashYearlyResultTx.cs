namespace FinanceCheckUp.Application.Models
{
    public class DashYearlyResultTx
    {
        public string Description { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
        public int TypeID { get; set; }




        public static List<DashYearlyResultTx> setDashBilanco(List<DashYearlyResult> mdash)
        {
            List<DashYearlyResultTx> nlist = new List<DashYearlyResultTx>();

            nlist = mdash.Select(x => new DashYearlyResultTx()
            {

                Description = x.Description,
                January = x.January,
                February = x.February,
                March = x.March,
                April = x.April,
                May = x.May,
                June = x.June,
                July = x.July,
                August = x.August,
                September = x.September,
                October = x.October,
                November = x.November,
                December = x.December,
                TypeID = x.TypeID
            }).ToList();
            return nlist;

        }

    }
}
