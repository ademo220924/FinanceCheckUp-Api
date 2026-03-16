using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IBultenManager : IGenericDapperRepository
{
    public Bulten Get_bulten(int ide);

    public IEnumerable<BWarn> Get_BWarn();

    public IEnumerable<BWarn> Get_BWarnCPM();
    public IEnumerable<Bulten> Get_All(int year_);

    public int Save_(Bulten bulten);
    public int Save_Apintment(Appointment apnt);
    public void UpdateApintment(Appointment apnt);

    public Appointment Getapintment(int apnt_);
    public void DELETEApintment(int apnt_);
    public void Update_(Bulten bulten);
}


public class BultenManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IBultenManager
{
    public Bulten Get_bulten(int ide)
    {
        return StaticQuery<Bulten>("Select * From  [dbo].[BULTEN] where ID=@ID", new { ID = ide }).FirstOrDefault();
    }

    public IEnumerable<BWarn> Get_BWarn()
    {
        return StaticQuery<BWarn>("Select * From  [dbo].[BWarn]");
    }

    public IEnumerable<BWarn> Get_BWarnCPM()
    {
        return StaticQuery<BWarn>("Select * From  [dbo].[BWarnSil]");
    }
    public IEnumerable<Bulten> Get_All(int year_)
    {
        return StaticQuery<Bulten>("Select * FROM  [dbo].[BULTEN] where YEAR([YururlulukTarih])=@year", new { year = year_ });
    }

    public int Save_(Bulten bulten)
    {
        string sql = @"  INSERT INTO  [dbo].[BULTEN]
          (  
        [Title] ,
        [SubTitle] ,
        [Kapsam] ,
        [YururlulukTarih] ,
        [DuzenleyenKurum] ,
        [Description] , 
        [CreatedUser]  
          ) 
           VALUES 
         (  
        @Title ,
        @SubTitle ,
        @Kapsam ,
        @YururlulukTarih,
        @DuzenleyenKurum,
        @Description , 
        @CreatedUser  

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        bulten.Id = Execute(sql, bulten);
        return bulten.Id;
    }
    public int Save_Apintment(Appointment apnt)
    {
        string sql = @"  INSERT INTO  [dbo].[Appointment]
          (  
        [Text] ,
        [Description] ,
        [StartDate] ,
        [EndDate] ,
        [AllDay] ,
        [PriorityId] , 
        [Status]  
          ) 
           VALUES 
         (  
        @Text ,
        @Description ,
        @StartDate ,
        @EndDate,
        @AllDay,
        @PriorityId , 
        @Status  

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
        apnt.Id = Execute(sql, apnt);
        return apnt.Id;


    }
    public void UpdateApintment(Appointment apnt)
    {
        string sql = @" UPDATE [dbo].[Appointment] SET  Text=@Text, Description=@Description, StartDate=@StartDate, EndDate=@EndDate, AllDay=@AllDay, PriorityId=@PriorityId, Status=@Status WHERE AppointmentId=@AppointmentId";
        Execute(sql, apnt);


    }
    public Appointment Getapintment(int apnt_)
    {
        string sql = @" SELECT * from  [dbo].[Appointment] WHERE AppointmentId=@apnt";
        return StaticQuery<Appointment>(sql, new { apnt = apnt_ }).FirstOrDefault();


    }
    public void DELETEApintment(int apnt_)
    {
        string sql = @" DELETE from  [dbo].[Appointment] WHERE AppointmentId=@apnt";
        Execute(sql, new { apnt = apnt_ });


    }
    public void Update_(Bulten bulten)
    {
        string sql = @"UPDATE  [dbo].[BULTEN] SET 
        [Title] =@Title,
        [SubTitle] = @SubTitle,
        [Kapsam] =@Kapsam,
        [YururlulukTarih]=@YururlulukTarih,
        [DuzenleyenKurum]=@DuzenleyenKurum,
        [Description]=@Description , 
        [CreatedUser]=@CreatedUser
        WHERE ID=@ID ";
        Execute(sql, bulten);
    }
}
