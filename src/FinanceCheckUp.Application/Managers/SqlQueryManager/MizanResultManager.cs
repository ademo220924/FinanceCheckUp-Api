using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IMizanResultManager : IGenericDapperRepository
{
    public List<DashMizanResult> Get_MizanResult(int _year, long _compID);
    public List<DashDonukView> Get_DonuChk(int _year, long _compID);
    public List<DashMizanResult> Get_TicariAlıcı(int _year, long _compID);
    public List<DashMizanResult> Get_TicariBorclu(int _year, long _compID);
    public List<DashMizanResult> Get_TicariAlıcıMizan(int _year, long _compID);
    public List<DashMizanResult> Get_TicariBorcluMizan(int _year, long _compID);
}


public class MizanResultManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IMizanResultManager
{
    public List<DashMizanResult> Get_MizanResult(int _year, long _compID)
    {
        return StaticQuery<DashMizanResult>("SELECT * FROM [dbo].[TBLMizanErrzoneResult]  where CompanyID=@companyID and [Year]=@nyear ", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashDonukView> Get_DonuChk(int _year, long _compID)
    {
        return StaticQuery<DashDonukView>("SELECT * from [dbo].[TBLMDONUKACCNTCHK]  where  OrderID<4 and  CompanyID=@companyID and [Year]=@nyear order by OrderID", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashMizanResult> Get_TicariAlıcı(int _year, long _compID)
    {
        return StaticQuery<DashMizanResult>("  SELECT top 5 [AccountSubDescription] as Description  , SUM([Amount]) as Amount FROM [dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear)  and AccountMainID = '120' and DebitCreditCode = 'D' group by[AccountSubDescription] order by SUM([Amount] ) desc", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashMizanResult> Get_TicariBorclu(int _year, long _compID)
    {
        return StaticQuery<DashMizanResult>("SELECT top 5 [AccountSubDescription] as Description , SUM([Amount]) as  Amount FROM [dbo].[TBLXMLSourceSub] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year = @nyear)  and AccountMainID = '320' and DebitCreditCode = 'C' group by[AccountSubDescription] order by SUM([Amount] ) desc", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashMizanResult> Get_TicariAlıcıMizan(int _year, long _compID)
    {
        return StaticQuery<DashMizanResult>("  SELECT top 5 [AccountSubDescription] as Description  , SUM([Amount]) as Amount FROM [dbo].[TBLXMLSourceOneT] where   CompanyID=@companyID and Year=@nyear  and AccountMainID = '120' and DebitCreditCode = 'D' group by[AccountSubDescription] order by SUM([Amount] ) desc", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashMizanResult> Get_TicariBorcluMizan(int _year, long _compID)
    {
        return StaticQuery<DashMizanResult>("SELECT top 5 [AccountSubDescription] as Description , SUM([Amount]) as  Amount FROM [dbo].[TBLXMLSourceOneT] where   CompanyID=@companyID and Year = @nyear  and AccountMainID = '320' and DebitCreditCode = 'C' group by[AccountSubDescription] order by SUM([Amount] ) desc", new { nyear = _year, companyID = _compID }).ToList();
    }
}
