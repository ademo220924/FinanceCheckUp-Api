using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;
using System.Drawing;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportPotDynamic
{
    public class MizanReportPotDynamicRequestInitialModel
    {
        public int UserID{ get; set;}
        public int YearCount{ get; set;}
        public List<ReportMainItem> ncheck{ get; set;}
        public List<ReportMainItem> nchecklast{ get; set;}
        public List<ReportMainItem> nchecka{ get; set;}
        public List<ReportMainItem> ncheck1{ get; set;}
        public List<ReportMainItem> ncheck1a{ get; set;}
        public List<ReportMainItem> ncheckb{ get; set;}
        public List<ReportMainItem> ncheckc{ get; set;}
        public List<ReportMainItem> ncheckd{ get; set;}
        public List<ReportMainItem> nchecke{ get; set;}
        public List<ReportMainItem> ncheckf{ get; set;}
        public List<ReportMainItem> ncheckg{ get; set;}
        public List<ReportMainItem> ncheck1_{ get; set;}
        public List<ReportMainItem> ncheck2{ get; set;}
        public List<ReportMainItem> ncheck3{ get; set;}
        public List<ReportMainItem> ncheck4{ get; set;}
        public List<ReportMainItem> ncheck5{ get; set;}
        public List<ReportMainItem> ncheck6{ get; set;}
        public List<ReportMainItem> ncheck7{ get; set;}
        public List<ReportMainItem> ncheck8{ get; set;}
        public List<ReportMainItem> ncheck9{ get; set;}
        public List<ReportMainItem> ncheck10{ get; set;}
        public List<ReportMainItem> ncheck11{ get; set;}
        public List<ReportMainItem> ncheck12{ get; set;}
        public ReportKapak ncheckKapak{ get; set;}
        public Color shape1{ get; set;}
        public Color shape2{ get; set;}
        public Color shape3{ get; set;}
        public Color shape4{ get; set;}
        public Color shape5{ get; set;}
        public Color shape6{ get; set;}
        public Color shape7{ get; set;}
        public Color shape8{ get; set;}
        public Color shape9{ get; set;}
        public List<ReportMainChart> ncheckchart{ get; set;}
        public List<ReportMainChart> ncheckchartb{ get; set;}
        public List<ReportMainChart> ncheckchart1{ get; set;}
        public List<ReportMainChart> ncheckchart2{ get; set;}
        public List<ReportMainChart> ncheckchart3{ get; set;}
        public List<ReportMainChart> ncheckchart4{ get; set;}
        public List<ReportMainChart> ncheckchart5{ get; set;}
        public List<ReportMainChart> ncheckchart6{ get; set;}
        public List<ReportMainChart> ncheckchart7{ get; set;}
        public List<ReportMainChart> ncheckchart8{ get; set;}
        public List<ReportMainChart> ncheckchart9{ get; set;}
        public List<ReportMainChart> ncheckchart10{ get; set;}
        public List<ReportMainChart> ncheckchart11{ get; set;}
        public List<ReportMainChart> ncheckchart12{ get; set;}
        public IEnumerable<Company> mreqListCompany{ get; set;}
        public HhvnUsers CurrentUser{ get; set;}
        public Company CCompanies{ get; set;}
        public int compnacecode{ get; set;}
        public long companyID{ get; set;}
        public bool Isfailed{ get; set;}
        public string repchakec{ get; set;}
        public string header{ get; set;}
        public string nccode{ get; set;}
        public List<string> fields{ get; set;}
        public List<string> fieldsHeader{ get; set;}
    }
}
