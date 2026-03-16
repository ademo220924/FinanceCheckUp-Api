using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashBilancoViewMizanCheckManager
{
    public DashBilancoViewMizanCheck SetBilanco(DashBilancoViewMizanCheck dashBilancoViewMizanCheck, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int hidden_);
    public DashBilancoViewMizanCheck SetBilancoHeaderT(DashBilancoViewMizanCheck dashBilancoViewMizanCheck, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int hidden_);
}


public class DashBilancoViewMizanCheckManager : IDashBilancoViewMizanCheckManager
{
    public DashBilancoViewMizanCheck SetBilanco(DashBilancoViewMizanCheck dashBilancoViewMizanCheck, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int hidden_)
    {
        var mrequest = mrequestEntryCount.OrderBy(x => x.AccountMainID).ToList();
        DashBilancoViewMizan nDash = new DashBilancoViewMizan();
        for (int i = 0; i < mrequest.Count(); i++)
        {
            dashBilancoViewMizanCheck.countet++;
            nDash = new DashBilancoViewMizan();
            nDash.CounterZone = dashBilancoViewMizanCheck.countet;
            nDash.GroupName = tname;
            nDash.AccountMainDescription = mrequest[i].AccountMainDescription;
            nDash.AccountMainID = mrequest[i].AccountMainID;
            nDash.Amount = mrequest[i].Amount;

            nDash.CompanyID = mrequest[i].CompanyID;
            nDash.DebitCreditCode = mrequest[i].DebitCreditCode;

            nDash.Year = mrequest[i].Year;
            nDash.IsHidden = hidden_;
            if (nDash.getStatue())
            {
                dashBilancoViewMizanCheck.mrequestEntry.Add(nDash);
            }

        }

        return dashBilancoViewMizanCheck;


    }

    public DashBilancoViewMizanCheck SetBilancoHeaderT(DashBilancoViewMizanCheck dashBilancoViewMizanCheck, List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int hidden_)
    {
        DashBilancoViewMizan nDash = new DashBilancoViewMizan();
        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            dashBilancoViewMizanCheck.countet++;
            nDash = new DashBilancoViewMizan
            {
                CounterZone = dashBilancoViewMizanCheck.countet,
                GroupName = tname,
                AccountMainDescription = tname,
                AccountMainID = mrequestEntryCount[i].AccountMainDescription,
                Amount = mrequestEntryCount[i].Amount,

                CompanyID = mrequestEntryCount[i].CompanyID,
                DebitCreditCode = mrequestEntryCount[i].DebitCreditCode,

                Year = mrequestEntryCount[i].Year,
                TypeID = typeid_,
                IsHidden = hidden_
            };
            if (nDash.getStatue())
            {
                dashBilancoViewMizanCheck.mrequestEntry.Add(nDash);
            }
        }

        return dashBilancoViewMizanCheck;
    }

}