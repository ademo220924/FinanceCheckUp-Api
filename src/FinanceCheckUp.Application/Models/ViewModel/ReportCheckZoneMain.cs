using DevExpress.XtraCharts;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.ViewModel;

public class ReportCheckZoneMain
{
        public static RiskDataColor rdColor { get; set; }
        public static RiskData riskdatachk { get; set; }
        public static RiskData riskdata { get; set; }
        public static long UserID { get; set; }
        public static int YearCount { get; set; }
        public static LineSeriesView checkSeries { get; set; }
        public static List<ReportMainItem> ncheck { get; set; }
        public static List<ReportMainItem> nchecklast { get; set; }
        public static List<ReportMainItem> nchecka { get; set; }
        public static List<ReportMainItem> ncheck1 { get; set; }
        public static List<ReportMainItem> ncheck1a { get; set; }
 
        public static List<ReportMainItem> ncheckb { get; set; }
        public static List<ReportMainItem> ncheckc { get; set; }
        public static List<ReportMainItem> ncheckd{ get; set; }
        public static List<ReportMainItem> nchecke{ get; set; }
        public static List<ReportMainItem> ncheckf{ get; set; }
        public static List<ReportMainItem> ncheckg{ get; set; }
        public static List<ReportMainItem> ncheck1_{ get; set; }
        public static List<ReportMainItem> ncheck2{ get; set; }
        public static List<ReportMainItem> ncheck3{ get; set; }
        public static List<ReportMainItem> ncheck4{ get; set; }
        public static List<ReportMainItem> ncheck5{ get; set; }
        public static List<ReportMainItem> ncheck6{ get; set; }
        public static List<ReportMainItem> ncheck7{ get; set; }
        public static List<ReportMainItem> ncheck8{ get; set; }
        public static List<ReportMainItem> ncheck9{ get; set; }
        public static List<ReportMainItem> ncheck10{ get; set; }
        public static List<ReportMainItem> ncheck11{ get; set; }
        public static List<ReportMainItem> ncheck12{ get; set; }
        public static ReportKapak ncheckKapak{ get; set; } 
        public static List<ReportMainChart> ncheckchart{ get; set; }
        public static List<ReportMainChart> ncheckchartb{ get; set; }
        public static List<ReportMainChart> ncheckchart1{ get; set; }
        public static List<ReportMainChart> ncheckchart2{ get; set; }
        public static List<ReportMainChart> ncheckchart3{ get; set; }
        public static List<ReportMainChart> ncheckchart4{ get; set; }
        public static List<ReportMainChart> ncheckchart5{ get; set; }
        public static List<ReportMainChart> ncheckchart6{ get; set; }
        public static List<ReportMainChart> ncheckchart7{ get; set; }
        public static List<ReportMainChart> ncheckchart8{ get; set; }
        public static List<ReportMainChart> ncheckchart9{ get; set; }
        public static List<ReportMainChart> ncheckchart10{ get; set; }
        public static List<ReportMainChart> ncheckchart11{ get; set; }
        public static List<ReportMainChart> ncheckchart12{ get; set; }
        public static IEnumerable<Company> mreqListCompany{ get; set; }
        public static HhvnUsers CurrentUser{ get; set; }
        public static Company CCompanies{ get; set; }
        public static int compnacecode{ get; set; }
        public static long companyID{ get; set; }
        public static bool Isfailed{ get; set; }
        public static string repchakec{ get; set; }
        public static string header{ get; set; }
        public static string nccode{ get; set; }
        public static IEnumerable<CsvDynamic> csvDynamiclist { get; set; }
        public static IEnumerable<CsvDynamicII> csvDynamicIIlist { get; set; }
        public static IEnumerable<CsvDynamicIII> csvDynamicIIIlist { get; set; }
        public static IEnumerable<CsvDynamicIIII> csvDynamicIIIIlist { get; set; }
}