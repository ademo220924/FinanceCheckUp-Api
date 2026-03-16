using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IErrorCheckMainManager : IGenericDapperRepository
{
    public List<ErrorCheckSet> Get_ReportSet();
    public void Set_ReportSet(int _CsvID);
    public List<DataViewer> Get_ReportSetAll(int _year, long _compID, int _month);
    public List<DataViewer> Get_ReportSetOther(int _year, long _compID, int _month);
}

public class ErrorCheckMainManager(FinanceCheckUpDbContext _dbContext, ITBLXmlManager tBLXmlManager) : GenericDapperRepositoryBase(_dbContext), IErrorCheckMainManager
{
    public List<ErrorCheckSet> Get_ReportSet()
    {
        return Query<ErrorCheckSet>("SELECT * FROM [dbo].[TBLErrzoneInside]").ToList();
    }


    public void Set_ReportSet(int _CsvID)
    {

        List<ErrorCheckSet> setM = Get_ReportSet();
        string nQueryId = string.Empty;
        string nsql = string.Empty;
        foreach (var item in setM)
        {
            nQueryId = "SPOW_ErrorInside" + item.QueryType.ToString();
            nsql = @"EXEC " + nQueryId + " @CsvID,@MainDesc,@MainDC,@MainDescChkIn,@MainDescChkInDC,@OutMainDesc,@OutMainDescDC,@CheckAmount,@InsideID";
            Execute(nsql, new { CsvID = _CsvID, MainDesc = item.MainDescription, MainDC = item.DebitCreditCode, MainDescChkIn = item.InMainDesc, MainDescChkInDC = item.InMainDescDC, item.OutMainDesc, item.OutMainDescDC, item.CheckAmount, InsideID = item.ID });
            Thread.Sleep(300);
        }
    }
    public List<DataViewer> Get_ReportSetAll(int _year, long _compID, int _month)
    {
        int _csvid = tBLXmlManager.GetComapnyIDByMonth(_compID, _month, _year);
        string sql = @" Select tb.[EntryNumber],tb.[DocumentDate],tb.[EnteredBy],tb.[AccountMainID],tb.[AccountMainDescription],tb.[AccountSubID]
,tb.[AccountSubDescription],tb.[DebitCreditCode],tb.[Amount],tb.[DetailComment],tb.[PaymentMethod],tb.[DocumentTypeDescription],tb.[EndDate],tb.[EntryComment],tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc  from  [dbo].[TBLErrzoneInsideXML] xt
                            LEFT  OUTER JOIN  TBLXMLSource as tb on tb.CsvID=xt.CsvID and tb.EntryNumber=xt.EntryNo
                            LEFT  OUTER JOIN [dbo].[TBLErrzoneInside] tt  on tt.ID=xt.ErrorInsideID
                            Where tb.CsvID=@csvID and tb.IsPassedEntry=0  and tb.IsFailed=1 and tt.ColorDesc>0 group by tb.[EntryNumber],tb.[DocumentDate],tb.[EnteredBy],tb.[AccountMainID],tb.[AccountMainDescription],tb.[AccountSubID]
,tb.[AccountSubDescription],tb.[DebitCreditCode],tb.[Amount],tb.[DetailComment],tb.[PaymentMethod],tb.[DocumentTypeDescription],tb.[EndDate],tb.[EntryComment],tt.Description , tt.ColorDesc ";


        return Query<DataViewer>(sql, new { csvID = _csvid }).ToList();
    }

    public List<DataViewer> Get_ReportSetOther(int _year, long _compID, int _month)
    {
        int _csvid = tBLXmlManager.GetComapnyIDByMonth(_compID, _month, _year);
        string sql = @"Select  tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from  [dbo].[TBLErrzoneInsideXML] xt
                            LEFT  OUTER JOIN  TBLXMLSource as tb on tb.CsvID=xt.CsvID and tb.EntryNumber=xt.EntryNo
                            LEFT  OUTER JOIN [dbo].[TBLErrzoneInside] tt  on tt.ID=xt.ErrorInsideID
                            Where tb.CsvID=@csvID and tb.IsPassedEntry=0  and tt.ColorDesc=0 and ( tt.[ColorDescTax]>0 or tt.[ColorDescInside]>0) group by tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], tt.ColorDescTax,tt.DescriptionTax , tt.ColorDescInside ,tt.DescriptionInside ";


        return Query<DataViewer>(sql, new { csvID = _csvid }).ToList();
    }

}
