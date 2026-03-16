using FinanceCheckUp.Application.Models.ViewModel;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashBilancoViewCheckQnbManager
{
    DashBilancoViewCheckQnb SetBilanco(DashBilancoViewCheckQnb model, List<DashBilancoViewQnb> mrequestEntryCount, string tname, int hidden_);
    DashBilancoViewCheckQnb SetBilancoHeaderT(DashBilancoViewCheckQnb model, List<DashBilancoViewQnb> mrequestEntryCount, string tnameCode, string tname, int typeid_, int hidden_);
}


public class DashBilancoViewCheckQnbManager : IDashBilancoViewCheckQnbManager
{
    public DashBilancoViewCheckQnb SetBilanco(DashBilancoViewCheckQnb model, List<DashBilancoViewQnb> mrequestEntryCount, string tname, int hidden_)
    {
        var mrequest = mrequestEntryCount.OrderBy(x => x.AccountMainID).ToList();
        DashBilancoViewQnb nDash = new DashBilancoViewQnb();
        for (int i = 0; i < mrequest.Count(); i++)
        {
            model.countet++;
            nDash = new DashBilancoViewQnb
            {
                CounterZone = model.countet,
                GroupName = tname,
                AccountMainDescription = mrequest[i].AccountMainDescription,
                AccountMainID = mrequest[i].AccountMainID,
                Amount = mrequest[i].Amount,
                Year = mrequest[i].Year,
                IsHidden = hidden_
            };
            model.mrequestEntry.Add(nDash);
        }

        return model;


    }

    public DashBilancoViewCheckQnb SetBilancoHeaderT(DashBilancoViewCheckQnb model, List<DashBilancoViewQnb> mrequestEntryCount, string tnameCode, string tname, int typeid_, int hidden_)
    {
        DashBilancoViewQnb nDash = new DashBilancoViewQnb();
        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            model.countet++;
            nDash = new DashBilancoViewQnb();
            nDash.CounterZone = model.countet;
            nDash.GroupName = tname;
            nDash.AccountMainDescription = tname;
            nDash.AccountMainID = tnameCode;
            nDash.Amount = mrequestEntryCount[i].Amount;
            nDash.Year = mrequestEntryCount[i].Year;
            nDash.TypeID = typeid_;
            nDash.IsHidden = hidden_;
            model.mrequestEntry.Add(nDash);

        }
        return model;

    }

}