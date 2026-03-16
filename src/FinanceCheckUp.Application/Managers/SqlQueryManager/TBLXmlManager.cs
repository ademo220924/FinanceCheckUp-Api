using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using System.Data;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface ITBLXmlManager : IGenericDapperRepository
{
    public IEnumerable<Tblxml> Get_TBLXml();
    public int GetComapnyIDByMonth(long compide, int monide, int yearide);
    public int GetMiissingByMonth(long compide);
    public int DeleteComapnyIDByMonth(long compide, int yearide, int monide);
    public int GetComapnyIDByMonthCount(long compide, int monide, int yearide);
    public int RESET_TBLXmlUpdate(long ide);
    public IEnumerable<Tblxml> Get_TBLXmlCompany(string ide);
    public Tblxml GetRow_TBLXml(string ide);
    public int GetYearByComapnyID(long ide);
    public int GetYearByComapnyIDMizan(long ide);
    public List<int> GetYearList(long ide);

    public int setCashFlow(long compide, int yearid);
    public int RESET_TBLXml(long ide);
    public int GetCountALL_byCompanyIDMulti(int _year, long _compID, int _monthID, long tblxmlID);
    public int RESETALL_byCompanyIDMulti(int _year, long _compID, int _monthID, long tblxmlID);
    public int RESETALL_byCompanyID(int _year, long _compID, int _monthID, long tblxmlID);
    public long Save_TBLXml(Tblxml tblxml);
    public bool Update_TBLXml(Tblxml tblxml);
    public void InsertTb(DataTable dt);
}


public class TBLXmlManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), ITBLXmlManager
{
    public IEnumerable<Tblxml> Get_TBLXml()
    {
        return Query<Tblxml>("Select * From [TBLXml]");
    }
    public int GetComapnyIDByMonth(long compide, int monide, int yearide)
    {
        return Query<int>("Select ID From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
    }
    public int GetMiissingByMonth(long compide)
    {
        return Query<int>("EXEC S_PCountMissing @compid", new { compid = compide }).FirstOrDefault();
    }
    public int DeleteComapnyIDByMonth(long compide, int yearide, int monide)
    {
        Query<int>("DELETE From [TBLXMLSource] where CsvID in (Select ID From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon) ", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
        return Query<int>("DELETE From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
    }
    public int GetComapnyIDByMonthCount(long compide, int monide, int yearide)
    {
        return Query<int>("Select Count(ID) From [TBLXml] where CompanyID=@ID and Year=@year and MONTH(DocumentDate)=@mon", new { ID = compide, year = yearide, mon = monide }).FirstOrDefault();
    }
    public int RESET_TBLXmlUpdate(long ide)
    {
        return Query<int>("EXEC RESETALL_byCSVIDUpdate @CsvID", new { CsvID = ide }).FirstOrDefault();
    }
    public IEnumerable<Tblxml> Get_TBLXmlCompany(string ide)
    {
        return Query<Tblxml>("Select * From [TBLXml] where CompanyID=@ID ", new { ID = ide });
    }
    public Tblxml GetRow_TBLXml(string ide)
    {
        return Query<Tblxml>("Select * From [TBLXml] where ID=@ID ", new { ID = ide }).FirstOrDefault();
    }
    public int GetYearByComapnyID(long ide)
    {
        return Query<int>("Select COUNT(DISTINCT(Year)) From [TBLXml] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
    }
    public int GetYearByComapnyIDMizan(long ide)
    {
        return Query<int>("Select COUNT(DISTINCT(Year)) From [TBLMizan] where CompanyID=@ID ", new { ID = ide }).FirstOrDefault();
    }
    public List<int> GetYearList(long ide)
    {
        return Query<int>("Select  DISTINCT([Year])  From [TBLXMLSourceOne] where CompanyID=@ID  and [Year]  not in (SELECT [Year] FROM [EDEFTERDB].[dbo].[TBLMNKTAKIS] where CompanyID=@ID ) order by [Year] ", new { ID = ide }).ToList();
    }

    public int setCashFlow(long compide, int yearid)
    {
        Query<int>("EXEC  [SP_ANAKITAKISALL]  @compdID,@nyear", new { compdID = compide, nyear = yearid });
        return Query<int>("EXEC  [SP_ANAKITAKISTALL]  @compdID,@nyear", new { compdID = compide, nyear = yearid }).FirstOrDefault();
    }
    public int RESET_TBLXml(long ide)
    {
        return Query<int>("EXEC RESETALL_byCSVID @CsvID", new { CsvID = ide }).FirstOrDefault();
    }
    public int GetCountALL_byCompanyIDMulti(int _year, long _compID, int _monthID, long tblxmlID)
    {
        int checkco = Query<int>("Select Count(ID) FROM [dbo].[TBLXMLSource]   where  CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and Year= @nyear and MONTH(DocumentDate)=@monD and ID<>@ide)", new { nyear = _year, companyID = _compID, monD = _monthID, ide = tblxmlID }).FirstOrDefault();
        return checkco;
    }
    public int RESETALL_byCompanyIDMulti(int _year, long _compID, int _monthID, long tblxmlID)
    {
        //Select Count(ID) FROM [dbo].[TBLXMLSource]   where  CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and Year= @nyear and MONTH(DocumentDate)=@monD and ID<>@ide)
        return Query<int>("EXEC RESETALL_byCompanyIDMulti @nyear, @companyID,@monD ,@ide", new { nyear = _year, companyID = _compID, monD = _monthID, ide = tblxmlID }).FirstOrDefault();
    }
    public int RESETALL_byCompanyID(int _year, long _compID, int _monthID, long tblxmlID)
    {
        return Query<int>("EXEC RESETALL_byCompanyID @nyear, @companyID,@monD ,@ide", new { nyear = _year, companyID = _compID, monD = _monthID, ide = tblxmlID }).FirstOrDefault();
    }
    public long Save_TBLXml(Tblxml tblxml)
    {
        string sql = @"  INSERT INTO [TBLXml]
          (  
        [CsvName] ,
        [CompanyID] ,
        [CreatedDate] ,
DocumentDate ,XmlDocName,Year
          ) 
           VALUES 
         (  
        @CsvName ,
        @CompanyID ,
        @CreatedDate ,
@DocumentDate ,@XmlDocName,@Year
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        tblxml.Id = Query<long>(sql, tblxml).FirstOrDefault();

        return tblxml.Id;
    }

    public bool Update_TBLXml(Tblxml tblxml)
    {
        try
        {
            string sql = "UPDATE   [TBLXml] SET     [CsvName]=@CsvName , [CompanyID]=@CompanyID , [CreatedDate]=@CreatedDate,DocumentDate=@DocumentDate, [Year]=@Year  WHERE [ID]=@ID";
            Execute(sql, tblxml);
            return true;
        }
        catch
        {
            throw;
        }
    }

    public void InsertTb(DataTable dt)
    {

        //    SqlConnection con = new SqlConnection(BaseModel.ConnectionString);
        //    SqlCommand com = new SqlCommand("SampleProcedure", con);
        //    com.CommandType = CommandType.StoredProcedure;

        //    SqlParameter parameter = new SqlParameter();
        //    parameter.ParameterName = "@Sample";
        //    parameter.SqlDbType = System.Data.SqlDbType.Structured;
        //    parameter.Value = dt;
        //    com.Parameters.Add(parameter);
        //    con.Open();

        //    com.ExecuteNonQuery();
        //    con.Close();
    }
    //public void InsertTb(DataTable dt)
    //{

    //    SqlConnection con = new SqlConnection(BaseModel.ConnectionString);
    //    SqlCommand com = new SqlCommand("SampleProcedure", con);
    //    com.CommandType = CommandType.StoredProcedure;

    //    SqlParameter parameter = new SqlParameter();
    //    parameter.ParameterName = "@Sample";
    //    parameter.SqlDbType = System.Data.SqlDbType.Structured;
    //    parameter.Value = dt;
    //    com.Parameters.Add(parameter);
    //    con.Open();

    //    com.ExecuteNonQuery();
    //    con.Close();

    //}
}