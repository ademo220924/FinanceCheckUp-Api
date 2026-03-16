using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;
public interface IDashBilancoSetQnbDSqlOperationManager : IGenericDapperRepository
{
    List<DashBilancoViewQnb> Get_1(int _year, long _compID);
    List<DashBilancoViewQnb> Get_2(int _year, long _compID);
    List<DashBilancoViewQnb> Get_3(int _year, long _compID);
    List<DashBilancoViewQnb> Get_4(int _year, long _compID);
    List<DashBilancoViewQnb> Get_5(int _year, long _compID);
    List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID);
    List<DashBilancoViewQnb> Get_ToplamA(int _year, long _compID);
    List<DashBilancoViewQnb> Get_ToplamB(int _year, long _compID);

}


public class DashBilancoSetQnbDSqlOperationManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IDashBilancoSetQnbDSqlOperationManager
{
    public List<DashBilancoViewQnb> Get_1(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,87", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_2(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,89", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_3(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnb @companyID, @nyear,91", new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<DashBilancoViewQnb> Get_4(int _year, long _compID)
    {
        return StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,93", new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DashBilancoViewQnb> Get_5(int _year, long _compID)
    {

        List<DashBilancoViewQnb> nlist = StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnb] @companyID, @nyear,95", new { nyear = _year, companyID = _compID }).ToList();

        if (nlist == null || nlist[0].Amount == 0)
        {

            List<DashBilancoViewQnb> nlist1 = StaticQuery<DashBilancoViewQnb>("EXEC [SP_Main_Grow_HeaderQnbSubTypeDonemKar] @companyID, @nyear,95", new { nyear = _year, companyID = _compID }).ToList();

            if (nlist1 == null || nlist1[0].Amount != 0)
            {
                string sqll = @"  IF NOT EXISTS (select top 1 * from [TBLXMLSourceOne] where AccountMainID='590' and CompanyID=@companyID and [Year]=@nyear)
   BEGIN
       INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,[Amount] ,[DebitCreditCode] ,[CompanyID] ,[AmountBakiye] ,[Year] ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,[MainAmountTotal] ,[Debit] ,[Credit]) select top 1 [TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,@amount ,[DebitCreditCode] ,@companyID ,@amount *-1  ,@nyear ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,@amount ,0 ,0 from [TBLXMLSourceOne] where AccountMainID='590' order by ID desc
   END
   ELSE
   BEGIN
   UPDATE TBLXMLSourceOne set AmountBakiye=@amount *-1,Amount=@amount,MainAmountTotal=@amount  where AccountMainID='590' and CompanyID=@companyID and [Year]=@nyear
   END";
                StaticQuery<DashBilancoViewQnb>(sqll, new { nyear = _year, companyID = _compID, amount = nlist1[0].Amount }).ToList();
                return nlist1;
            }
            else
            {
                return nlist1;
            }
            //INSERT INTO [dbo].[TBLXMLSourceOne] ([TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,[Amount] ,[DebitCreditCode] ,[CompanyID] ,[AmountBakiye] ,[Year] ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,[MainAmountTotal] ,[Debit] ,[Credit]) select top 1 [TypeID] ,[AccountMainID] ,[AccountMainDescription] ,[AccountMainEng] ,@amount ,[DebitCreditCode] ,@companyID ,@amount*-1 ,@year ,[SubTypeID] ,[MainTypeID] ,[IsNegative] ,[IsErrored] ,@amount ,0 ,0 from [TBLXMLSourceOne] where AccountMainID='590' order by ID desc
        }
        else
        {
            return nlist;
        }


    }

    public List<DashBilancoViewQnb> Get_Toplam(int _year, long _compID)
    {
        List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubType @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();
        if (nnnn == null)
        {
            nnnn = new List<DashBilancoViewQnb>();
            DashBilancoViewQnb ll = new DashBilancoViewQnb();
            nnnn.Add(ll);
        }

        return nnnn;


    }
    public List<DashBilancoViewQnb> Get_ToplamA(int _year, long _compID)
    {
        List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubTypeB @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();

        if (nnnn == null)
        {
            nnnn = new List<DashBilancoViewQnb>();
            DashBilancoViewQnb ll = new DashBilancoViewQnb();
            nnnn.Add(ll);
        }

        return nnnn;

    }
    public List<DashBilancoViewQnb> Get_ToplamB(int _year, long _compID)
    {
        List<DashBilancoViewQnb> nnnn = StaticQuery<DashBilancoViewQnb>("EXEC SP_Main_Grow_HeaderQnbSubTypeC @companyID, @nyear,5", new { nyear = _year, companyID = _compID }).ToList();

        if (nnnn == null)
        {
            nnnn = new List<DashBilancoViewQnb>();
            DashBilancoViewQnb ll = new DashBilancoViewQnb();
            nnnn.Add(ll);
        }

        return nnnn;


    }

}