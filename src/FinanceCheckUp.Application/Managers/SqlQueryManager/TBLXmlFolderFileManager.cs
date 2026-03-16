using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface ITBLXmlFolderFileManager : IGenericDapperRepository
{
    public List<TblxmlFolderFile> GetList(long _ID);
    public List<ViewSortlist> GetListSort(long _ID);
}

public class TBLXmlFolderFileManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ITBLXmlFolderFileManager
{
    public List<TblxmlFolderFile> GetList(long _ID)
    {
        return StaticQuery<TblxmlFolderFile>("Select [CompanyID],[MainMonth],[MainYear],[Issetted] FROM [EDEFTERDB].[dbo].[TBLXmlFolderFile] where [CompanyID]=@ID and IsLedger=1  and [CreatedDate]> DATEADD(MINUTE,-130, GETDATE()) order by ID ", new { ID = _ID }).ToList();
    }
    public List<ViewSortlist> GetListSort(long _ID)
    {
        string sql = @"  SELECT SUM(t.AllSet) as 'AllSet',SUM(t.AllWait) as  'AllWait',SUM(t.AllRecord) as  'AllRecord',t.MainYear from
                             (Select 
                             Case When [Issetted]=1 Then COUNT(*) ELSE 0 END as 'AllSet',
                             Case When [Issetted]=0 Then COUNT(*) ELSE 0 END as  'AllWait',
                             Count(*) as  'AllRecord', [MainYear]
                              FROM [EDEFTERDB].[dbo].[TBLXmlFolderFile] where [CompanyID]=@ID and IsLedger=1  group by [Issetted],[MainYear],[CompanyID])t group by t.MainYear";

        return StaticQuery<ViewSortlist>(sql, new { ID = _ID }).ToList();
    }
}
