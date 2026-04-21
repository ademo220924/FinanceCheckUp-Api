using FinanceCheckUp.Application.Models.ViewModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Reports;

/// <summary>
/// ReportCheckZoneold, ReportCheckZoneMain ve ComReport için DevExpress rapor bağlama verisinin API taşıması.
/// Renkler System.Drawing.Color yerine ARGB int olarak taşınır.
/// </summary>
public class FinancialReportZonePayloadResponse
{
    public List<ReportMainItem> Ncheck { get; set; }
    public List<ReportMainItem> NcheckLast { get; set; }
    public List<ReportMainItem> NcheckA { get; set; }
    public List<ReportMainItem> Ncheck1 { get; set; }
    public List<ReportMainItem> Ncheck1a { get; set; }
    public List<ReportMainItem> NcheckB { get; set; }
    public List<ReportMainItem> NcheckC { get; set; }
    public List<ReportMainItem> NcheckD { get; set; }
    public List<ReportMainItem> NcheckE { get; set; }
    public List<ReportMainItem> NcheckF { get; set; }
    public List<ReportMainItem> NcheckG { get; set; }
    /// <summary>ncheck1_ listesi</summary>
    public List<ReportMainItem> Ncheck1Underscore { get; set; }
    public List<ReportMainItem> Ncheck2 { get; set; }
    public List<ReportMainItem> Ncheck3 { get; set; }
    public List<ReportMainItem> Ncheck4 { get; set; }
    public List<ReportMainItem> Ncheck5 { get; set; }
    public List<ReportMainItem> Ncheck6 { get; set; }
    public List<ReportMainItem> Ncheck7 { get; set; }
    public List<ReportMainItem> Ncheck8 { get; set; }
    public List<ReportMainItem> Ncheck9 { get; set; }
    public List<ReportMainItem> Ncheck10 { get; set; }
    public List<ReportMainItem> Ncheck11 { get; set; }
    public List<ReportMainItem> Ncheck12 { get; set; }

    public ReportKapak NcheckKapak { get; set; }

    public int? ShapeArgb1 { get; set; }
    public int? ShapeArgb2 { get; set; }
    public int? ShapeArgb3 { get; set; }
    public int? ShapeArgb4 { get; set; }
    public int? ShapeArgb5 { get; set; }
    public int? ShapeArgb6 { get; set; }
    public int? ShapeArgb7 { get; set; }
    public int? ShapeArgb8 { get; set; }
    public int? ShapeArgb9 { get; set; }

    public List<ReportMainChart> NcheckChart { get; set; }
    public List<ReportMainChart> NcheckChartB { get; set; }
    public List<ReportMainChart> NcheckChart1 { get; set; }
    public List<ReportMainChart> NcheckChart2 { get; set; }
    public List<ReportMainChart> NcheckChart3 { get; set; }
    public List<ReportMainChart> NcheckChart4 { get; set; }
    public List<ReportMainChart> NcheckChart5 { get; set; }
    public List<ReportMainChart> NcheckChart6 { get; set; }
    public List<ReportMainChart> NcheckChart7 { get; set; }
    public List<ReportMainChart> NcheckChart8 { get; set; }
    public List<ReportMainChart> NcheckChart9 { get; set; }
    public List<ReportMainChart> NcheckChart10 { get; set; }
    public List<ReportMainChart> NcheckChart11 { get; set; }
    public List<ReportMainChart> NcheckChart12 { get; set; }

    public RiskDataColor RdColor { get; set; }
    public RiskData RiskData { get; set; }
    public RiskData RiskDataChk { get; set; }

    public int CompNaceCode { get; set; }
    public string Repchakec { get; set; }
    public string Header { get; set; }
    public string Nccode { get; set; }
    public int? YearCount { get; set; }
    public bool? Isfailed { get; set; }

    public List<string> Fields { get; set; }
    public List<string> FieldsHeader { get; set; }
}
