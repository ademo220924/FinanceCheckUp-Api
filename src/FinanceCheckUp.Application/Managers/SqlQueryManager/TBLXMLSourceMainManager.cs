using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface ITBLXMLSourceMainManager : IGenericDapperRepository
{
    public IEnumerable<TblxmlsourceMain> Get_AllCompany(int _year, long _compID);
    public IEnumerable<TblxmlsourceMain> Get_AllCompanyLast(int _year, long _compID);
}


public class TBLXMLSourceMainManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ITBLXMLSourceMainManager
{
    public IEnumerable<TblxmlsourceMain> Get_AllCompany(int _year, long _compID)
    {
        return StaticQuery<TblxmlsourceMain>("Select * From [TBLXMLSourceMain] Where CsvID in ( Select ID From [TBLXml] where   CompanyID=@companyID and [Year]=@nyear)", new { companyID = _compID, nyear = _year });
    }
    public IEnumerable<TblxmlsourceMain> Get_AllCompanyLast(int _year, long _compID)
    {
        return StaticQuery<TblxmlsourceMain>("Select * From [TBLXMLSourceSub] Where CsvID in ( Select ID From [TBLXml] where   CompanyID=@companyID and [Year]=@nyear)", new { companyID = _compID, nyear = _year });
    }
}