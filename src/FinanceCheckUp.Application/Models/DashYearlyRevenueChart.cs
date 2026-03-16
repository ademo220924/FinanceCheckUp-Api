namespace FinanceCheckUp.Application.Models;

public class DashYearlyRevenueChart
{
    public DashYearlyRevenueChart()
    {
        nresult = new List<DashYearlyRevenueMain>();
    }
    public List<DashYearlyRevenueMain> nresult { get; set; }

    public void SetResult(List<DashBilancoView> tdash, int nyear)
    {
        DashYearlyRevenueMain nv = new();


        string txyear = nyear.ToString();
        foreach (var item in tdash)
        {
            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/01/15");
            nv.SortVal = 1;
            nv.Value = item.January;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/02/15");
            nv.SortVal = 2;
            nv.Value = item.February;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/03/15");
            nv.SortVal = 3;
            nv.Value = item.March;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/04/15");
            nv.SortVal = 4;
            nv.Value = item.April;
            nv.GroupName = item.GroupName;
            nv.TypeID = item.TypeID;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/05/15");
            nv.SortVal = 5;
            nv.Value = item.May;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/06/15");
            nv.SortVal = 6;
            nv.Value = item.June;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nv.TypeID = item.TypeID;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/07/15");
            nv.SortVal = 7;
            nv.Value = item.July;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/08/15");
            nv.SortVal = 8;
            nv.Value = item.August;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/09/15");
            nv.SortVal = 9;
            nv.Value = item.September;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/10/15");
            nv.SortVal = 10;
            nv.Value = item.October;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/11/15");
            nv.SortVal = 11;
            nv.Value = item.November;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

            nv = new DashYearlyRevenueMain();
            nv.Description = item.AccountMainDescription;
            nv.Month = DateTime.Parse(txyear + "/12/15");
            nv.SortVal = 12;
            nv.Value = item.December;
            nv.TypeID = item.TypeID;
            nv.GroupName = item.GroupName;
            nv.CountrZone = item.CounterZone;
            nresult.Add(nv);

        }


    }
}
