namespace FinanceCheckUp.Application.Models
{
    public class DashLikiditeCheck
    {
        public DashLikiditeCheck()
        {
            mrequestEntry = new List<DashBilancoView>();

        }
        public List<DashBilancoView> mrequestEntry { get; set; }

        public void SetBilanco(List<DashBilancoView> mrequestEntryCount, string tname)
        {
            int countet = mrequestEntry.Count();
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoView();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
                nDash.Acilis = mrequestEntryCount[i].Acilis;
                nDash.April = mrequestEntryCount[i].April;
                nDash.August = mrequestEntryCount[i].August;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.December = mrequestEntryCount[i].December;
                nDash.February = mrequestEntryCount[i].February;
                nDash.January = mrequestEntryCount[i].January;
                nDash.July = mrequestEntryCount[i].July;
                nDash.June = mrequestEntryCount[i].June;
                nDash.May = mrequestEntryCount[i].May;
                nDash.March = mrequestEntryCount[i].March;
                nDash.November = mrequestEntryCount[i].November;
                nDash.October = mrequestEntryCount[i].October;
                nDash.September = mrequestEntryCount[i].September;
                nDash.Year = mrequestEntryCount[i].Year;
                mrequestEntry.Add(nDash);
            }

        }

        public void SetBilancoHeaderT(List<DashBilancoView> mrequestEntryCount, string tname, string mainname)
        {
            int countet = mrequestEntry.Count();
            DashBilancoView nDash = new DashBilancoView();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoView();
                nDash.CounterZone = countet;
                nDash.GroupName = mainname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
                nDash.Acilis = mrequestEntryCount[i].Acilis;
                nDash.April = mrequestEntryCount[i].April;
                nDash.August = mrequestEntryCount[i].August;
                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
                nDash.December = mrequestEntryCount[i].December;
                nDash.February = mrequestEntryCount[i].February;
                nDash.January = mrequestEntryCount[i].January;
                nDash.July = mrequestEntryCount[i].July;
                nDash.June = mrequestEntryCount[i].June;
                nDash.May = mrequestEntryCount[i].May;
                nDash.March = mrequestEntryCount[i].March;
                nDash.November = mrequestEntryCount[i].November;
                nDash.October = mrequestEntryCount[i].October;
                nDash.September = mrequestEntryCount[i].September;
                nDash.Year = mrequestEntryCount[i].Year;
                if (nDash.OverViewTotal != 0)
                {
                    mrequestEntry.Add(nDash);
                }

            }

        }

    }
}
