using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Managers.StaticManagers;
public interface IDashGelirTablosuViewTManager
{
    public DashGelirTablosuViewT SetBilanco(DashGelirTablosuViewT dashGelirTablosuViewT, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int ishidden);
    public DashGelirTablosuViewT SetBilancoHeaderT(DashGelirTablosuViewT dashGelirTablosuViewT, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int ishidden);
}

public class DashGelirTablosuViewTManager : IDashGelirTablosuViewTManager
{
    public DashGelirTablosuViewT SetBilanco(DashGelirTablosuViewT dashGelirTablosuViewT, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int ishidden)
    {
        DashBilancoViewMizan nDash = new DashBilancoViewMizan();
        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            dashGelirTablosuViewT.counter++;
            nDash = new DashBilancoViewMizan();
            nDash.GroupName = tname;
            nDash.AccountMainDescription = mrequestEntryCount[i].AccountMainDescription;
            nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
            nDash.Amount = mrequestEntryCount[i].Amount;
            nDash.CompanyID = mrequestEntryCount[i].CompanyID;
            nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
            nDash.Year = mrequestEntryCount[i].Year;
            nDash.TypeID = 0;
            nDash.CounterZone = dashGelirTablosuViewT.counter;
            nDash.IsHidden = ishidden;
            dashGelirTablosuViewT.mrequestEntryMizan.Add(nDash);
        }

        return dashGelirTablosuViewT;
    }

    public DashGelirTablosuViewT SetBilancoHeaderT(DashGelirTablosuViewT dashGelirTablosuViewT, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int ishidden)
    {
        dashGelirTablosuViewT.counter++;
        DashBilancoViewMizan nDash = new DashBilancoViewMizan();
        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            nDash = new DashBilancoViewMizan();
            nDash.GroupName = tname;
            nDash.AccountMainDescription = tname;
            nDash.AccountMainID = mrequestEntryCount[i].AccountMainID;
            nDash.Amount = mrequestEntryCount[i].Amount;
            nDash.CompanyID = mrequestEntryCount[i].CompanyID;
            nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;
            nDash.Year = mrequestEntryCount[i].Year;
            nDash.TypeID = typeid_;
            nDash.IsHidden = ishidden;
            nDash.CounterZone = dashGelirTablosuViewT.counter;

            dashGelirTablosuViewT.mrequestEntryMizan.Add(nDash);
        }

        return dashGelirTablosuViewT;
    }
}