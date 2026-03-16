namespace FinanceCheckUp.Application.Models
{
    public class DashYearlyResultWorkingCapital
    {
        public int Year { get; set; }
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
        public long CompanyID { get; set; }


        public static DashYearlyResultWorkingCapital setProp(int monthid, DashYearlyResultWorkingCapital nt)
        {

            if (nt == null)
            {
                return new DashYearlyResultWorkingCapital();
            }

            switch (monthid)
            {
                case 1: nt.February = 0; nt.March = 0; nt.April = 0; nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 2: nt.March = 0; nt.April = 0; nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 3: nt.April = 0; nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 4: nt.May = 0; nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 5: nt.June = 0; nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 6: nt.July = 0; nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 7: nt.August = 0; nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 8: nt.September = 0; nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 9: nt.October = 0; nt.November = 0; nt.December = 0; return nt;
                case 10: nt.November = 0; nt.December = 0; return nt;
                case 11: nt.December = 0; return nt;
                default:
                    return nt;
            }


        }
    }
}
