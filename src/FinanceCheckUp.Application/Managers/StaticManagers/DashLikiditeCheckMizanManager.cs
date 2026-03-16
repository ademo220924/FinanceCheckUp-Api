using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.StaticManagers;
public interface IDashLikiditeCheckMizanManager : IGenericDapperRepository
{
    public DashLikiditeCheckMizan SetBilanco(DashLikiditeCheckMizan dashLikiditeCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname);
    public DashLikiditeCheckMizan SetBilancoHeaderT(DashLikiditeCheckMizan dashLikiditeCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname, string mainname);
}


public class DashLikiditeCheckMizanManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashLikiditeCheckMizanManager
{
    public DashLikiditeCheckMizan SetBilanco(DashLikiditeCheckMizan dashLikiditeCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname)
    {
        int countet = dashLikiditeCheckMizan.mrequestEntry.Count();
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
                dashLikiditeCheckMizan.mrequestEntry.Add(nDash);
            }

        }
        return dashLikiditeCheckMizan;

    }

    public DashLikiditeCheckMizan SetBilancoHeaderT(DashLikiditeCheckMizan dashLikiditeCheckMizan, List<DashBilancoViewMizan> mrequestEntryCount, string tname, string mainname)
    {
        int countet = dashLikiditeCheckMizan.mrequestEntry.Count();

        for (int i = 0; i < mrequestEntryCount.Count(); i++)
        {
            countet++;
            DashBilancoViewMizan nDash = new DashBilancoViewMizan
            {
                CounterZone = countet,
                GroupName = mainname,
                AccountMainDescription = tname,
                AccountMainID = mrequestEntryCount[i].AccountMainDescription,
                Amount = mrequestEntryCount[i].Amount,
                Year = mrequestEntryCount[i].Year
            };
            if (nDash.Amount != 0)
            {
                dashLikiditeCheckMizan.mrequestEntry.Add(nDash);
            }

        }
        return dashLikiditeCheckMizan;

    }
}