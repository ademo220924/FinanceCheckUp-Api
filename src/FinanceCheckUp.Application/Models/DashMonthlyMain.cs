namespace FinanceCheckUp.Application.Models
{
    public class DashMonthlyMain
    {
        public string AccountMainDescription { get; set; }
        public decimal Acilis { get; set; }
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

        public static List<DashMonthlyMain> GetlistFromSub(IEnumerable<DashMonthlySub> nlist)
        {
            List<DashMonthlyMain> flist = new List<DashMonthlyMain>();
            DashMonthlyMain fitem = new DashMonthlyMain();
            foreach (var item in nlist)
            {
                fitem = new DashMonthlyMain();
                fitem.AccountMainDescription = item.AccountSubDescription;
                fitem.Acilis = item.Acilis;
                fitem.April = item.April;
                fitem.August = item.August;
                fitem.CompanyID = item.CompanyID;
                fitem.December = item.December;
                fitem.February = item.February;
                fitem.January = item.January;
                fitem.July = item.July;
                fitem.June = item.June;
                fitem.March = item.March;
                fitem.May = item.May;
                fitem.November = item.November;
                fitem.October = item.October;
                fitem.September = item.September;
                flist.Add(fitem);
            }
            return flist;


        }
    }
}
