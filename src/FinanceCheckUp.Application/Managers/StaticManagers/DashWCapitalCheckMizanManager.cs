using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IDashWCapitalCheckMizanManager : IGenericDapperRepository
{
    public DashWCapitalCheckMizan SetBilanco(DashWCapitalCheckMizan dashWCapitalCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname);
    public DashWCapitalCheckMizan SetBilancoHeaderT(DashWCapitalCheckMizan dashWCapitalCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname, string mainname);
}


public class DashWCapitalCheckMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashWCapitalCheckMizanManager
{
    public DashWCapitalCheckMizan SetBilanco(DashWCapitalCheckMizan dashWCapitalCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname)
    {
        int countet = dashWCapitalCheckMizan.mrequestEntry.Count();
        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            countet++;
            DashBilancoViewMizan nDash = new DashBilancoViewMizan
            {
                CounterZone = countet,
                GroupName = tname,
                AccountMainDescription = mrequestEntryCount[i].AccountMainDescription,
                AccountMainID = mrequestEntryCount[i].AccountMainDescription,
                Amount = mrequestEntryCount[i].Amount,
                Year = mrequestEntryCount[i].Year
            };
            if (nDash.Amount != 0)
            {
                dashWCapitalCheckMizan.mrequestEntry.Add(nDash);
            }

        }
        return dashWCapitalCheckMizan;

    }

    public DashWCapitalCheckMizan SetBilancoHeaderT(DashWCapitalCheckMizan dashWCapitalCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname, string mainname)
    {
        int countet = dashWCapitalCheckMizan.mrequestEntry.Count();
        DashBilancoViewMizan nDash = new DashBilancoViewMizan();
        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            countet++;
            nDash = new DashBilancoViewMizan();
            nDash.CounterZone = countet;
            nDash.GroupName = mainname;
            nDash.AccountMainDescription = tname;
            nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
            nDash.Amount = mrequestEntryCount[i].Amount;
            nDash.Year = mrequestEntryCount[i].Year;
            if (nDash.Amount != 0)
            {
                dashWCapitalCheckMizan.mrequestEntry.Add(nDash);
            }

        }
        return dashWCapitalCheckMizan;
    }
}