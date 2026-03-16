using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;


namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface ITBLXmlFileManager : IGenericDapperRepository
{
    public TblxmlFile GetNewFile();
    public bool GetNewFileBool();
    public IEnumerable<TblxmlFile> Get_TBLXmlIDlist(long ide);
    public TblxmlFile Get_TBLXmlFile(long ide, int sortid_);
    public IEnumerable<TblxmlFile> _SetFirstSetted(long ide);
    public int Delete_TBLXmlIDlist(long ide);
    public long Save_TBLXmlFile(TblxmlFile tblxmlFile);
    public bool Finish_TBLXmlFile(TblxmlFile tblxmlFile);
    public bool Update_TBLXmlFile(TblxmlFile tblxmlFile);
}


public class TBLXmlFileManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ITBLXmlFileManager
{
    public TblxmlFile GetNewFile()
    {
        return StaticQuery<TblxmlFile>("UPDATE [TBLXmlFile]  SET IsSetted = 1 OUTPUT Inserted.* WHERE ID = (Select top 1 ID from [TBLXmlFile] where IsSetted = 0)").FirstOrDefault();
    }
    public bool GetNewFileBool()
    {
        return StaticQuery<bool>("SELECT CASE WHEN EXISTS (Select top 1 ID from [TBLXmlFile] where IsSetted = 0) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END").FirstOrDefault();
    }
    public IEnumerable<TblxmlFile> Get_TBLXmlIDlist(long ide)
    {
        return StaticQuery<TblxmlFile>("Select * From [TBLXmlFile] where TBLXmlID=@ID ", new { ID = ide });
    }
    public TblxmlFile Get_TBLXmlFile(long ide, int sortid_)
    {
        return StaticQuery<TblxmlFile>("Select top 1 *,(Select Count(*)  From [TBLXmlFile] where TBLXmlID=@ID and Issetted=0) as LastSettedCount From [TBLXmlFile] where TBLXmlID=@ID and SortID=@sortid", new { ID = ide, sortid = sortid_ }).FirstOrDefault();
    }
    public IEnumerable<TblxmlFile> _SetFirstSetted(long ide)
    {
        return StaticQuery<TblxmlFile>("UPDATE  [TBLXmlFile] set Issetted=1 where ID=(Select top 1  ID  from [TBLXmlFile] where TBLXmlID=@ID order by ID asc) ", new { ID = ide });
    }
    public int Delete_TBLXmlIDlist(long ide)
    {
        return StaticQuery<int>("Delete From [TBLXmlFile] where TBLXmlID=@ID ", new { ID = ide }).FirstOrDefault();
    }
    public long Save_TBLXmlFile(TblxmlFile tblxmlFile)
    {
        string sql = @"  INSERT INTO [TBLXmlFile]
        ([CsvName] ,[TBLXmlID],SortID) 
           VALUES 
         (@CsvName,@TBLXmlID,@SortID)  ;
         select  Cast(SCOPE_IDENTITY() as Int) ";



        tblxmlFile.Id = Query<long>(sql, tblxmlFile).FirstOrDefault();
        return tblxmlFile.Id;
    }
    public bool Finish_TBLXmlFile(TblxmlFile tblxmlFile)
    {
        try
        {
            string sql = "UPDATE   [TBLXmlFile] SET     [IsFinished]=1  WHERE [ID]=@ID";
            Execute(sql, tblxmlFile);
            return true;
        }
        catch
        {
            throw;
        }
    }
    public bool Update_TBLXmlFile(TblxmlFile tblxmlFile)
    {
        try
        {
            string sql = "UPDATE   [TBLXmlFile] SET     [Issetted]=1  WHERE [ID]=@ID";
            Execute(sql, tblxmlFile);
            return true;
        }
        catch
        {
            throw;
        }
    }
}