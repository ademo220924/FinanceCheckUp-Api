using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;

public interface IMainDashManager : IGenericDapperRepository
{
    public IEnumerable<YearlyErrorResult> Get_Data(int _year, long _compID);
    public IEnumerable<YearlyErrorResult> Get_DatabyError(int _year, long _compID);
    public List<int> Get_DatabyMOnthMizan(int _year, long _compID);
    public IEnumerable<YearlyErrorResult> Get_DatabyErrorV1(int _year, long _compID, int _monID);
    public DataViewerErroredCountCsv Get_DatabyErrorbyCsv(long _Csvid);
    public int GetTblxml(int _year, long _compID, int _monID);
    public int GetMainReport(int _year, long _compID, int _monID);
    public List<YearlyErrorResult> DataViewerTaxError(int _year, long _compID);
    public List<DataViewer> DataViewerMain(int _year, long _compID);
    public List<DataViewer> DataViewerMainMonth(int _year, long _compID, int _nmonth);
    public List<TBLErrColor> DataTBLErrColor();
    public DataViewerError DataViewerCheckOne(string mainDescription_);
    public int DataErrorSetter(DataViewerError _dataGroup);
    public int DataCheckSetter(DataViewerCheck _dataGroup);
    public List<DataViewer> DataViewerMainSourceT(int _year, long _compID, int monthid_);
    public List<DataViewer> DataViewerMainSource(int _year, long _compID, int monthid_);
    public List<ReportMainItem> DataReportMain(int _year, long _compID);
    public List<DashBilancoViewQnb> DataReportMainQnb(int _year, long _compID);
    public List<DashBilancoViewQnb> DataReportMainQnbT(long _compID);
    public List<DashBilancoViewQnb> DataReportMainQnbGelirT(long _compID);
    public List<DashBilancoViewQnb> DataReportMainQnbGelir(int _year, long _compID);
    public List<ReportMainItem> DataReportMainDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainCompanyList(long _compID);
    public List<ReportMainItem> DataReportMainA(int _year, long _compID);
    public List<ReportMainItem> DataReportMainADynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainBDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainCDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainDDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainEDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainFDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainGDynamic(int[] _year, long _compID);
    public List<ReportMainItem> DataReportMainB(int _year, long _compID);
    public List<ReportMainItem> DataReportMainC(int _year, long _compID);
    public List<ReportMainItem> DataReportMainD(int _year, long _compID);
    public List<ReportMainItem> DataReportMainE(int _year, long _compID);
    public List<ReportMainItem> DataReportMainF(int _year, long _compID);
    public List<ReportMainItem> DataReportMainG(int _year, long _compID);
    public List<ReportMainItem> DataReportMainT(int _year, long _compID);
    public List<ReportMainItem> DataReportMainTDynamic(int[] _year, long _compID);
    public List<ReportMainChartQnb> DataReportMain1DynamicMainChart(long _compID);
    public List<ReportMainItemQnb> DataReportMain1DynamicMain(long _compID);
    public List<ReportMainItem> DataReportMain1Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain2Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain3Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain4Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain5Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain6Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain7Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain8Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain9Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain10Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain11Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain12Dynamic(int[] _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain1(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain2(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain3(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain4(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain5(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain6(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain7(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain8(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain9(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain10(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain11(int _year, long _compID, int _naceID);
    public List<ReportMainItem> DataReportMain12(int _year, long _compID, int _naceID);
    public IEnumerable<ReportMainItem> DataReportMainKapak(int _year, long _compID);
    public IEnumerable<ReportMainItem> DataReportMainKapakDynamic(int _year, long _compID);
    public List<ReportMainChart> DataReportMainChart(ReportMainItem _nItem);
    public List<ReportMainChartQnb> DataReportMainChartMultiQnb(ReportMainItemQnb _nItem, int chk_);
    public List<ReportMainChart> DataReportMainChartMulti(ReportMainItem _nItem);
    public List<ReportMainChart> DataReportMainChartMain(List<ReportMainItem> _nItem);
    public List<ReportMainChart> DataReportMainChartMainMulti(IEnumerable<ReportMainItem> _nItem);
}


public class MainDashManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IMainDashManager
{
    public IEnumerable<YearlyErrorResult> Get_Data(int _year, long _compID)
    {
        return StaticQuery<YearlyErrorResult>("Select * from [TBLDBMONCOM] where CompanyID=@companyID and MainYear= @nyear", new { nyear = _year, companyID = _compID });
    }
    public IEnumerable<YearlyErrorResult> Get_DatabyError(int _year, long _compID)
    {
        return StaticQuery<YearlyErrorResult>("Select * from [TBLDBMONCOM] where CompanyID=@companyID and MainYear= @nyear", new { nyear = _year, companyID = _compID });
    }
    public List<int> Get_DatabyMOnthMizan(int _year, long _compID)
    {
        return StaticQuery<int>("Select DISTINCT(MainMonth) from [TBLXMLSourceOneBck] where CompanyID=@companyID and [Year]= @nyear", new { nyear = _year, companyID = _compID }).ToList();
    }
    public IEnumerable<YearlyErrorResult> Get_DatabyErrorV1(int _year, long _compID, int _monID)
    {
        return StaticQuery<YearlyErrorResult>("EXEC [SP_ROWERRORBYMONTHV1] @nyear,@companyID,@monId", new { nyear = _year, companyID = _compID, monId = _monID });
    }
    public DataViewerErroredCountCsv Get_DatabyErrorbyCsv(long _Csvid)
    {
        return StaticQuery<DataViewerErroredCountCsv>("EXEC [SP_ROWONLLYERRORBYCsv] @Csvid", new { Csvid = _Csvid }).FirstOrDefault();
    }
    public int GetTblxml(int _year, long _compID, int _monID)
    {
        string sql = @" Select TOP 1 ID from TBLXML  where  CompanyID=@companyID and [Year]=@nyear and MONTH(DocumentDate)=@monid  ";

        return StaticQuery<int>(sql, new { nyear = _year, companyID = _compID, monid = _monID }).FirstOrDefault();
    }
    public int GetMainReport(int _year, long _compID, int _monID)
    {
        string sql = @" Select TOP 1 ID from TBLXML  where  CompanyID=@companyID and [Year]=@nyear and MONTH(DocumentDate)=@monid  ";

        return StaticQuery<int>(sql, new { nyear = _year, companyID = _compID, monid = _monID }).FirstOrDefault();
    }
    public List<YearlyErrorResult> DataViewerTaxError(int _year, long _compID)
    {
        string sql = @"EXEC [SP_ROWERRORTAXBYMONTH] @nyear,@companyID";

        return StaticQuery<YearlyErrorResult>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    //SELECT COUNT(*),MONTH(t.DocumentDate) as MainMonth FROM [dbo].[TBLErrzoneInsideXML] tb WITH(NOLOCK) LEFT JOIN TblXml t   on tb.CsvID=t.ID where  t.CompanyID= 8 and t.Year = 2021  group by t.DocumentDate
    //
    public List<DataViewer> DataViewerMain(int _year, long _compID)
    {
        string sql = @" Select * from [TBLDataErrored]  where CompanyID=@companyID and [Year]=@nyear  ";

        return StaticQuery<DataViewer>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<DataViewer> DataViewerMainMonth(int _year, long _compID, int _nmonth)
    {
        string sql = @" Select * from [TBLDataErrored]  where CompanyID=@companyID and [Year]=@nyear and MONTH(EndDate)=@nmonth ";

        return StaticQuery<DataViewer>(sql, new { nyear = _year, companyID = _compID, nmonth = _nmonth }).ToList();
    }
    public List<TBLErrColor> DataTBLErrColor()
    {
        string sql = @" Select * from [TBLErrColor] ";

        return StaticQuery<TBLErrColor>(sql).ToList();
    }
    public DataViewerError DataViewerCheckOne(string mainDescription_)
    {
        string sql = @" Select TOP 1 * from [TBLErrzone]  where TRIM(MainDescription)=TRIM(@mainDescription)";

        return StaticQuery<DataViewerError>(sql, new { mainDescription = mainDescription_ }).FirstOrDefault();
    }


    public int DataErrorSetter(DataViewerError _dataGroup)
    {
        try
        {
            string sql1 = string.Empty;


            if (_dataGroup.Id == "0" || _dataGroup.Id == "null" || string.IsNullOrEmpty(_dataGroup.Id))
            {
                sql1 = @"INSERT INTO TBLErrzone([MainDescription]
      ,[ColorDesc]
      ,[Description]
      ,[ColorDescTax]
      ,[DescriptionTax]
      ,[ColorDescInside]
      ,[DescriptionInside])
      VALUES(@mainDescription,@colorDesc,@description,@colorDescTax,@descriptionTax,@colorDescInside,@descriptionInside) ";
                StaticQuery<string>(sql1, new { mainDescription = _dataGroup.MainDescription, colorDesc = _dataGroup.ColorDesc, description = _dataGroup.Description, colorDescTax = _dataGroup.ColorDescTax, descriptionTax = _dataGroup.DescriptionTax, colorDescInside = _dataGroup.ColorDescInside, descriptionInside = _dataGroup.DescriptionInside });
            }
            else
            {
                sql1 = @"UPDATE TBLErrzone  SET [MainDescription]=@mainDescription 
      ,[ColorDesc]=@colorDesc 
      ,[Description]= @description
      ,[ColorDescTax]=@colorDescTax
      ,[DescriptionTax]=@descriptionTax
      ,[ColorDescInside]=@colorDescInside
      ,[DescriptionInside] =@descriptionInside
      WHERE ID=@ide";

                StaticQuery<string>(sql1, new { mainDescription = _dataGroup.MainDescription, colorDesc = _dataGroup.ColorDesc, description = _dataGroup.Description, colorDescTax = _dataGroup.ColorDescTax, descriptionTax = _dataGroup.DescriptionTax, colorDescInside = _dataGroup.ColorDescInside, descriptionInside = _dataGroup.DescriptionInside, ide = _dataGroup.Id });
            }

        }
        catch (Exception ex)
        {
            var chk = ex;
        }

        return 1;
    }
    public int DataCheckSetter(DataViewerCheck _dataGroup)
    {
        try
        {
            string sql1 = @"INSERT INTO  [dbo].[TBLWzone] (MainDescriptionID,[MainDescription] )
      VALUES(@mainDescriptionInfo,@mainDescription) ";
            StaticQuery<string>(sql1, new { mainDescription = _dataGroup.MainDescription, mainDescriptionInfo = _dataGroup.DescriptionInfo });
        }
        catch (Exception ex)
        {

            var chk = ex;
        }

        return 1;
    }
    public List<DataViewer> DataViewerMainSourceT(int _year, long _compID, int monthid_)
    {



        //string sql3 = @" Select tb.*,tt.Description ,tt.ColorDesc ,tt.ColorDescTax,tt.DescriptionTax ,tt.ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
        //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
        //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
        //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and xt.CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear) ";

        //string sql = @" Select tb.*,tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc,ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
        //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
        //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
        //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and tt.ColorDesc>0 and xt.CsvID = (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid) ";
        string sqll = @"EXEC [SP_CAccountErrorr] @nyear,@companyID,@monthid";
        //            string sql = @"  Select EntryNumber,DocumentDate,EnteredBy,AccountMainID,AccountMainDescription,AccountSubID,AccountSubDescription,DebitCreditCode,Amount,DetailComment,PaymentMethod,DocumentTypeDescription,EndDate   From TBLXMLSource  where EntryNumber in
        //(
        //  			SELECT
        //  MIN(EntryNumber) TEntryNumber 
        //FROM
        //     [dbo].[CSVGRUPTA]  WHERE IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
        //GROUP BY
        //    [AccountMainIDList])    and  CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)";
        //            string sql = @"   Select c.EntryNumber,c.DocumentDate,c.EnteredBy,c.AccountMainID,c.AccountMainDescription,c.AccountSubID,c.AccountSubDescription,c.DebitCreditCode,c.Amount,c.DetailComment,c.PaymentMethod,c.DocumentTypeDescription,c.EndDate   From TBLXMLSource as c  JOIN  
        //(
        //     SELECT   Max(EntryNumber) as TentryNumber ,Max([TotalCredit]) as TTotalCredit
        //FROM
        //(
        //    SELECT   TOP 1000000  [AccountMainIDList], EntryNumber ,[TotalCredit]
        //    FROM  [dbo].[CSVGRUPTA]  where IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
        //    ORDER BY EntryNumber
        //) u Group By EntryNumber , [AccountMainIDList])t on t.TentryNumber=c.EntryNumber and t.TTotalCredit=c.TotalCredit ";
        return StaticQuery<DataViewer>(sqll, new { nyear = _year, companyID = _compID, monthid = monthid_ }).ToList();
    }
    public List<DataViewer> DataViewerMainSource(int _year, long _compID, int monthid_)
    {



        //string sql3 = @" Select tb.*,tt.Description ,tt.ColorDesc ,tt.ColorDescTax,tt.DescriptionTax ,tt.ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
        //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
        //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
        //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and xt.CsvID in (Select ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear) ";

        //string sql = @" Select tb.*,tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc,ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from [TBLDataErrored] as tb
        //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
        //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
        //                Where tb.CompanyID=@companyID and tb.[Year]=@nyear and MONTH(tb.EndDate)=@monthid and xt.CsvID = (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid) ";

        //string sqlT = @"Select tb.*,tt.Description ,ISNULL(tt.ColorDesc,0) as  ColorDesc,ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside  from [TBLXMLSource]  as tb WITH (NOLOCK)
        //                LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
        //                LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
        //                Where  xt.CsvID = (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid)  and (tt.ColorDescTax>0 or tt.ColorDescInside>0)";

        string sqll = @"Select  tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], ISNULL(tt.ColorDescTax,0) as  ColorDescTax,tt.DescriptionTax , ISNULL(tt.ColorDescInside,0) as  ColorDescInside ,tt.DescriptionInside from [TBLXMLSource]  as tb WITH (NOLOCK)
                            LEFT OUTER JOIN [dbo].[XmlCheckGroup] xt  on tb.EntryNumber=xt.EntryNumber
                            LEFT OUTER JOIN [dbo].[TBLErrzone] tt  on tt.MainDescription=xt.AccountMainIDList
                            Where  xt.CsvID =  (Select TOP 1 ID FROM TBLXml where CompanyID=@companyID and [Year]=@nyear  and MONTH(DocumentDate)=@monthid)   and (tt.ColorDescTax>0 or tt.ColorDescInside>0) group by tb.[EntryNumber]      ,tb.[DocumentDate]      ,tb.[EnteredBy]      ,tb.[AccountMainID]      ,tb.[AccountMainDescription]      ,tb.[AccountSubID]
      ,tb.[AccountSubDescription]      ,tb.[DebitCreditCode]      ,tb.[Amount]      ,tb.[DetailComment]      ,tb.[PaymentMethod]      ,tb.[DocumentTypeDescription]      ,tb.[EndDate]      ,tb.[EntryComment], tt.ColorDescTax,tt.DescriptionTax , tt.ColorDescInside ,tt.DescriptionInside ";
        //            string sql = @"  Select EntryNumber,DocumentDate,EnteredBy,AccountMainID,AccountMainDescription,AccountSubID,AccountSubDescription,DebitCreditCode,Amount,DetailComment,PaymentMethod,DocumentTypeDescription,EndDate   From TBLXMLSource  where EntryNumber in
        //(
        //  			SELECT
        //  MIN(EntryNumber) TEntryNumber 
        //FROM
        //     [dbo].[CSVGRUPTA]  WHERE IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
        //GROUP BY
        //    [AccountMainIDList])    and  CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)";
        //            string sql = @"   Select c.EntryNumber,c.DocumentDate,c.EnteredBy,c.AccountMainID,c.AccountMainDescription,c.AccountSubID,c.AccountSubDescription,c.DebitCreditCode,c.Amount,c.DetailComment,c.PaymentMethod,c.DocumentTypeDescription,c.EndDate   From TBLXMLSource as c  JOIN  
        //(
        //     SELECT   Max(EntryNumber) as TentryNumber ,Max([TotalCredit]) as TTotalCredit
        //FROM
        //(
        //    SELECT   TOP 1000000  [AccountMainIDList], EntryNumber ,[TotalCredit]
        //    FROM  [dbo].[CSVGRUPTA]  where IsFailed=1 and CsvID in (Select ID From TBLXml Where CompanyID=@companyID and [Year]=@nyear)
        //    ORDER BY EntryNumber
        //) u Group By EntryNumber , [AccountMainIDList])t on t.TentryNumber=c.EntryNumber and t.TTotalCredit=c.TotalCredit ";
        return StaticQuery<DataViewer>(sqll, new { nyear = _year, companyID = _compID, monthid = monthid_ }).ToList();
    }
    public List<ReportMainItem> DataReportMain(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT01 where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";
        var ttt = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        return ttt;
    }
    public List<DashBilancoViewQnb> DataReportMainQnb(int _year, long _compID)
    {

        string sql = @"Select * from TBLMQnbReport where   CompanyID=@companyID and  [Year]=@nyear and  MainTypeID in (1,2,3,4,5,6,7,8,9,11) and TypeID not in (7,9,11,15,17,19,21,55,57,59) order by TypeID";
        var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { nyear = _year, companyID = _compID }).ToList();
        return ttt;
    }
    public List<DashBilancoViewQnb> DataReportMainQnbT(long _compID)
    {

        string sql = @"Select * from TBLMQnbReportShrt where   CompanyID=@companyID   and  MainTypeID in (1,2,3,4,5,6,7,8,9,11)  and TypeID not in (7,9,11,15,17,19,21,55,57,59) order by TypeID";
        var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { companyID = _compID }).ToList();
        return ttt;
    }
    public List<DashBilancoViewQnb> DataReportMainQnbGelirT(long _compID)
    {

        string sql = @"Select * from TBLMQnbReportShrt where   CompanyID=@companyID  and  MainTypeID not in (1,2,3,4,5,6,7,8,9,11) order by TypeID";
        var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { companyID = _compID }).ToList();
        return ttt;
    }

    public List<DashBilancoViewQnb> DataReportMainQnbGelir(int _year, long _compID)
    {

        string sql = @"Select * from TBLMQnbReport where   CompanyID=@companyID and  [Year]=@nyear and  MainTypeID not in (1,2,3,4,5,6,7,8,9,11) order by TypeID";
        var ttt = StaticQuery<DashBilancoViewQnb>(sql, new { nyear = _year, companyID = _compID }).ToList();
        return ttt;
    }

    public List<ReportMainItem> DataReportMainDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT01MZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";
        string sql = @"Select * from TBMLREPORT01MZN where   CompanyID=@companyID and  [Year] in @nyear   order by CounterZone";
        var ttt = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        return ttt;
    }
    public List<ReportMainItem> DataReportMainCompanyList(long _compID)
    {

        string sql = @"Select  [CompanyID]      ,[Year] from TBMLREPORT01 where   CompanyID=@companyID   group by  [CompanyID]      ,[Year]";

        return StaticQuery<ReportMainItem>(sql, new { companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainA(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT01A where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainADynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT01AMZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";

        string sql = @"Select * from TBMLREPORT01AMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainBDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT03MZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";
        string sql = @"Select * from TBMLREPORT03MZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainCDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT031AMZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";

        string sql = @"Select * from TBMLREPORT031AMZN where   CompanyID=@companyID and  [Year]  in @nyear    order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainDDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT05MZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";
        string sql = @"Select * from TBMLREPORT05MZN where   CompanyID=@companyID and  [Year] in @nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainEDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT051AMZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";
        string sql = @"Select * from TBMLREPORT051AMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainFDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT051BMZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";

        string sql = @"Select * from TBMLREPORT051BMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainGDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT051CMZN SOH  where SOH.CompanyID=@companyID 
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";

        //
        string sql = @"Select * from TBMLREPORT051CMZN where   CompanyID=@companyID and  [Year] in @nyear    order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainB(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT03 where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<ReportMainItem> DataReportMainC(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT031A where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }

    public List<ReportMainItem> DataReportMainD(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT05 where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainE(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT051A where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainF(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT051B where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainG(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT051C where   CompanyID=@companyID and  [Year]=@nyear  order by CounterZone";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainT(int _year, long _compID)
    {

        string sql = @"Select * from TBMLREPORT07 where   CompanyID=@companyID and  [Year]=@nyear   and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }
    public List<ReportMainItem> DataReportMainTDynamic(int[] _year, long _compID)
    {
        //            string sqla = @"SELECT * FROM 
        //(
        //SELECT SOH.GroupName, SOH.CounterZone, SOH.Year  as SalesYear,
        //        SOH.TumYil as TotalSales
        // FROM TBMLREPORT07MZN SOH  where SOH.CompanyID=@companyID  and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)
        //) AS Sales
        //PIVOT (SUM(TotalSales)
        //FOR SalesYear IN @nyear )
        //as PVT order by CounterZone";
        string sql = @"Select * from TBMLREPORT07MZN where   CompanyID=@companyID and  [Year] in @nyear   and CounterZone not in(11,33,111,133,255,277,299,377,499,533,577,599)";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
    }



    public List<ReportMainChartQnb> DataReportMain1DynamicMainChart(long _compID)
    {

        List<ReportMainChartQnb> nget = new List<ReportMainChartQnb>();
        string sql = @"SELECT [ID]
      ,[AccountMainID] as GridName
      ,[AccountMainDescription] as GroupName 
      ,[Amount] 
      ,[CompanyID]
      ,[Year] as GroupText
      ,[TypeID]  
  FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioChart] where CompanyID=@companyID ";



        nget = StaticQuery<ReportMainChartQnb>(sql, new { companyID = _compID }).ToList();


        return nget;
    }

    public List<ReportMainItemQnb> DataReportMain1DynamicMain(long _compID)
    {

        List<ReportMainItemQnb> nget = new List<ReportMainItemQnb>();
        string sql = @"SELECT [ID]
      ,[AccountMainID]
      ,[AccountMainDescription] as GroupName 
      ,[AccountMainDescription] as GridName  
      ,cast([Amount] as decimal(25,2)) as Amount
    ,cast([Amount1] as decimal(25,2)) as Amount1
    ,cast([Amount2] as decimal(25,2)) as Amount2
    ,cast([Amount3] as decimal(25,2)) as Amount3
    ,cast([Amount4] as decimal(25,2)) as Amount4
      ,[CompanyID] 
      ,[TypeID]
      ,[MainTypeID]
      ,[ColorID]
  FROM [EDEFTERDB].[dbo].[TBLMQnbReportRatioChartShrt] where CompanyID=@companyID ";



        nget = StaticQuery<ReportMainItemQnb>(sql, new { companyID = _compID }).ToList();


        return nget;
    }

    public List<ReportMainItem> DataReportMain1Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=11 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil,YIL+2 as Year   FROM [dbo].[TBLBANKAKREDIAKTIFLER] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain2Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=33 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBANKAKREDIYABKAYNAK] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain3Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=111 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year   FROM [dbo].[TBLDURANVARLIKOZKYNK] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain4Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=133 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBDONENVARLIKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain5Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=255 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBKVADEALACKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain6Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=277 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBKVADEALACKDONEN] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain7Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=299 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBKVADEKYNKPASIF] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain8Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=377 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil  ,YIL+2 as Year   FROM [dbo].[TBLBMDDIDURANOKAYNK] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain9Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=499 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil  ,YIL+2 as Year   FROM [dbo].[TBLBSTOKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain10Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=533 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year   FROM [dbo].[TBLBUVADEYABKYNKPSF] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain11Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=577 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBOKYNKAKTIF] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain12Dynamic(int[] _year, long _compID, int _naceID)
    {
        List<int> _nyear = _year.Select(c => { c = c - 2; return c; }).ToList();
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07MZN] where   CompanyID=@companyID and CounterZone=599 and [Year] IN @nyear ";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,YIL+2 as Year    FROM [dbo].[TBLBOKYNKYBNCIKYNK] where [YIL] IN  @nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _nyear, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain1(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear  and CounterZone=11";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBANKAKREDIAKTIFLER] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain2(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=33";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBANKAKREDIYABKAYNAK] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain3(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=111";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLDURANVARLIKOZKYNK] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain4(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=133";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBDONENVARLIKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain5(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=255";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBKVADEALACKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain6(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=277";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBKVADEALACKDONEN] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain7(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=299";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBKVADEKYNKPASIF] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    //TBLBOKYNKYBNCIKYNK,TBLBOKYNKAKTIF,TBLBUVADEYABKYNKPSF,TBLBSTOKAKTIF,TBLBMDDIDURANOKAYNK,,,,,,,,,,,,,,,,,,,
    public List<ReportMainItem> DataReportMain8(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=377";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBMDDIDURANOKAYNK] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain9(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=499";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBSTOKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public List<ReportMainItem> DataReportMain10(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=533";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBUVADEYABKYNKPSF] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    public List<ReportMainItem> DataReportMain11(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=577";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBOKYNKAKTIF] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }
    //
    //TBLBOKYNKYBNCIKYNK,TBLBOKYNKAKTIF,TBLBUVADEYABKYNKPSF,,,,,,,,,,,,,,,,,,,,,
    //
    public List<ReportMainItem> DataReportMain12(int _year, long _compID, int _naceID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        List<ReportMainItem> nget1 = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPORT07] where   CompanyID=@companyID and  [Year]=@nyear and CounterZone=599";

        nget1 = StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID }).ToList();
        nget.AddRange(nget1);

        nget1 = new List<ReportMainItem>();
        string sql1 = @"  SELECT 'Sektorel' as GroupName, [TUMYIL] as TumYil ,[Q1]  ,[Q2] ,[Q3]  FROM [dbo].[TBLBOKYNKYBNCIKYNK] where [YIL]=@nyear and [NACE]=@nace";
        nget1 = StaticQuery<ReportMainItem>(sql1, new { nyear = _year - 2, nace = _naceID }).ToList();
        nget.AddRange(nget1);

        return nget;
    }

    public IEnumerable<ReportMainItem> DataReportMainKapak(int _year, long _compID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPOR01] where   CompanyID=@companyID and  [Year]=@nyear";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID });

    }
    public IEnumerable<ReportMainItem> DataReportMainKapakDynamic(int _year, long _compID)
    {
        List<ReportMainItem> nget = new List<ReportMainItem>();
        string sql = @"Select * from [dbo].[TBMLREPOR01MZN] where   CompanyID=@companyID and  [Year]=@nyear";

        return StaticQuery<ReportMainItem>(sql, new { nyear = _year, companyID = _compID });

    }

    public List<ReportMainChart> DataReportMainChart(ReportMainItem _nItem)
    {
        List<ReportMainChart> ncheck = new List<ReportMainChart>();
        ReportMainChart ncha = new ReportMainChart();
        ncha.GroupName = _nItem.GroupName;
        ncha.GroupText = "Q1";
        ncha.Value = _nItem.Q1;
        ncheck.Add(ncha);
        ncha = new ReportMainChart();
        ncha.GroupName = _nItem.GroupName;
        ncha.GroupText = "Q2";
        ncha.Value = _nItem.Q2;
        ncheck.Add(ncha);
        ncha = new ReportMainChart();
        ncha.GroupName = _nItem.GroupName;
        ncha.GroupText = "Q3";
        ncha.Value = _nItem.Q3;
        ncheck.Add(ncha);
        ncha = new ReportMainChart();
        ncha.GroupName = _nItem.GroupName;
        ncha.GroupText = "TumYil";
        ncha.Value = _nItem.TumYil;
        ncheck.Add(ncha);

        return ncheck;
    }



    public List<ReportMainChartQnb> DataReportMainChartMultiQnb(ReportMainItemQnb _nItem, int chk_)
    {
        List<ReportMainChartQnb> ncheck = new List<ReportMainChartQnb>();
        ReportMainChartQnb ncha = new ReportMainChartQnb();

        ncha.GridName = _nItem.GroupName;
        ncha.GroupText = _nItem.Year.ToString();
        switch (chk_)
        {
            case 1: ncha.Amount = _nItem.Amount; break;
            default:
                break;
        }

        ncheck.Add(ncha);

        return ncheck;
    }

    public List<ReportMainChart> DataReportMainChartMulti(ReportMainItem _nItem)
    {
        List<ReportMainChart> ncheck = new List<ReportMainChart>();
        ReportMainChart ncha = new ReportMainChart();
        ncha.GroupName = _nItem.GroupName;
        ncha.GroupText = _nItem.Year.ToString();
        ncha.Value = _nItem.TumYil;
        ncheck.Add(ncha);

        return ncheck;
    }
    public List<ReportMainChart> DataReportMainChartMain(List<ReportMainItem> _nItem)
    {
        List<ReportMainChart> ncheck = new List<ReportMainChart>();

        foreach (var item in _nItem)
        {
            ncheck.AddRange(DataReportMainChart(item));
        }

        return ncheck;
    }
    public List<ReportMainChart> DataReportMainChartMainMulti(IEnumerable<ReportMainItem> _nItem)
    {
        List<ReportMainChart> ncheck = new List<ReportMainChart>();

        foreach (var item in _nItem)
        {
            ncheck.AddRange(DataReportMainChartMulti(item));
        }

        return ncheck;
    }

}
