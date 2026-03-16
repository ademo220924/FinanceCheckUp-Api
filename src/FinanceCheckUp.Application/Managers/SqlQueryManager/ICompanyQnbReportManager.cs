using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface ICompanyQnbReportManager : IGenericDapperRepository
    {
        public CompanyQnbReport Get_CompanyReport(long reportide);
        public List<CompanyQnbReport> Get_CompanyReportList(long comide);
        public int Get_CompanyReportCount(long reportide);
        public int Set_Report(long compide, long useride, string reportname);
    }


    public class CompanyQnbReportManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ICompanyQnbReportManager
    {
        public CompanyQnbReport Get_CompanyReport(long reportide)
        {

            return StaticQuery<CompanyQnbReport>("SELECT * FROM CompanyQnbReport  where   ID=@ID", new { ID = reportide }).FirstOrDefault();
        }
        public List<CompanyQnbReport> Get_CompanyReportList(long comide)
        {

            return StaticQuery<CompanyQnbReport>("SELECT * FROM CompanyQnbReport  where   CompanyID=@ID", new { ID = comide }).ToList();
        }
        public int Get_CompanyReportCount(long reportide)
        {
            return StaticQuery<int>("SELECT COUNT(*) FROM CompanyQnbReport  where  CompanyID=@ID", new { ID = reportide }).FirstOrDefault();
        }
        public int Set_Report(long compide, long useride, string reportname)
        {
            return StaticQuery<int>("EXEC SPP_SaveReportDocument @CompID,@UserID,@fileName", new { CompID = compide, UserID = useride, fileName = reportname }).FirstOrDefault();
        }
    }
}
