using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Application.Models.ViewModel;

namespace FinanceCheckUp.Application.Mapper;

/// <summary>
/// FinansRaporu / FinansRaporua / FinansRaporub / FinansRaporuc raporları atanmış veri kaynağından
/// API DTO üretir.
/// </summary>
internal static class FinansRaporZonePayloadExtractor
{
    public static FinancialReportZonePayloadResponse FromXtraReport(XtraReport report)
    {
        var p = new FinancialReportZonePayloadResponse();

        var xrCompany = report.FindControl("xr7CompanyName", true) as XRLabel;
        var xrNace = report.FindControl("xr7NaceKod", true) as XRLabel;
        p.Header = xrCompany?.Text;
        p.Nccode = xrNace?.Text;

        AssignCharts(report, p);
        AssignDetailBands(report.Bands, p);

        return p;
    }

    private static void AssignCharts(XtraReport report, FinancialReportZonePayloadResponse p)
    {
        var charts = new List<List<ReportMainChart>>(24);
        for (var i = 1; i <= 24; i++)
        {
            if (report.FindControl("xrChart" + i, true) is not XRChart chart)
            {
                charts.Add(new List<ReportMainChart>());
                continue;
            }

            charts.Add(ExtractChartData(chart));
        }

        var lists = charts.Select(x => x).ToList();
        p.NcheckChart = At(lists, 0);
        p.NcheckChartB = At(lists, 1);
        for (var j = 0; j <= 11; j++)
        {
            var slot = At(lists, j + 2);
            SetChartSlot(p, j, slot);
        }
    }

    private static List<ReportMainChart> At(List<List<ReportMainChart>> lists, int index) =>
        index >= 0 && index < lists.Count ? lists[index] : new List<ReportMainChart>();

    private static void SetChartSlot(FinancialReportZonePayloadResponse p, int j, List<ReportMainChart> slot)
    {
        switch (j)
        {
            case 0: p.NcheckChart1 = slot; break;
            case 1: p.NcheckChart2 = slot; break;
            case 2: p.NcheckChart3 = slot; break;
            case 3: p.NcheckChart4 = slot; break;
            case 4: p.NcheckChart5 = slot; break;
            case 5: p.NcheckChart6 = slot; break;
            case 6: p.NcheckChart7 = slot; break;
            case 7: p.NcheckChart8 = slot; break;
            case 8: p.NcheckChart9 = slot; break;
            case 9: p.NcheckChart10 = slot; break;
            case 10: p.NcheckChart11 = slot; break;
            case 11: p.NcheckChart12 = slot; break;
        }
    }

    private static List<ReportMainChart> ExtractChartData(XRChart chart)
    {
        var ds = chart.DataSource;
        if (ds is IEnumerable<ReportMainChartQnb> qnb)
            return ReportZoneViewModelConverter.FromChartQnbList(qnb);
        if (ds is IEnumerable<object> eo)
            return ReportZoneViewModelConverter.FromChartQnbList(eo.OfType<ReportMainChartQnb>());
        return new List<ReportMainChart>();
    }

    private static void AssignDetailBands(BandCollection bands, FinancialReportZonePayloadResponse p)
    {
        var rows = new List<List<ReportMainItem>>();
        CollectDetailDataSources(bands, rows);
        AssignMainRows(p, rows);
    }

    private static void CollectDetailDataSources(BandCollection bands, List<List<ReportMainItem>> rows)
    {
        foreach (Band band in bands)
        {
            if (band is DetailReportBand dr)
            {
                var list = ExtractRowList(dr);
                if (list.Count > 0)
                    rows.Add(list);
                if (dr.Bands is { Count: > 0 })
                    CollectDetailDataSources(dr.Bands, rows);
            }
        }
    }

    private static List<ReportMainItem> ExtractRowList(DetailReportBand dr)
    {
        if (dr.DataSource is not ObjectDataSource ods)
            return new List<ReportMainItem>();

        return ConvertDataSource(ods.DataSource);
    }

    private static List<ReportMainItem> ConvertDataSource(object raw)
    {
        if (raw == null) return new List<ReportMainItem>();
        if (raw is IEnumerable<ReportMainItem> rim)
            return rim.ToList();
        if (raw is IEnumerable<ReportMainItemQnb> qnb)
            return ReportZoneViewModelConverter.FromQnbList(qnb);
        if (raw is IEnumerable<DashBilancoViewQnb> dq)
            return ReportZoneViewModelConverter.FromDashList(dq);
        if (raw is DashBilancoViewQnb singleDash)
            return ReportZoneViewModelConverter.FromDashList(new[] { singleDash });
        if (raw is ReportMainItemQnb singleQ)
            return ReportZoneViewModelConverter.FromQnbList(new[] { singleQ });
        if (raw is IEnumerable<object> eo)
            return ReportZoneViewModelConverter.FromObjectList(eo);
        return new List<ReportMainItem>();
    }

    private static void AssignMainRows(FinancialReportZonePayloadResponse p, List<List<ReportMainItem>> mapped)
    {
        var named = new Action[]
        {
            () => p.Ncheck = PickRow(mapped, 0),
            () => p.NcheckLast = PickRow(mapped, 1),
            () => p.NcheckA = PickRow(mapped, 2),
            () => p.Ncheck1 = PickRow(mapped, 3),
            () => p.Ncheck1a = PickRow(mapped, 4),
            () => p.NcheckB = PickRow(mapped, 5),
            () => p.NcheckC = PickRow(mapped, 6),
            () => p.NcheckD = PickRow(mapped, 7),
            () => p.NcheckE = PickRow(mapped, 8),
            () => p.NcheckF = PickRow(mapped, 9),
            () => p.NcheckG = PickRow(mapped, 10),
            () => p.Ncheck1Underscore = PickRow(mapped, 11),
            () => p.Ncheck2 = PickRow(mapped, 12),
            () => p.Ncheck3 = PickRow(mapped, 13),
            () => p.Ncheck4 = PickRow(mapped, 14),
            () => p.Ncheck5 = PickRow(mapped, 15),
            () => p.Ncheck6 = PickRow(mapped, 16),
            () => p.Ncheck7 = PickRow(mapped, 17),
            () => p.Ncheck8 = PickRow(mapped, 18),
            () => p.Ncheck9 = PickRow(mapped, 19),
            () => p.Ncheck10 = PickRow(mapped, 20),
            () => p.Ncheck11 = PickRow(mapped, 21),
            () => p.Ncheck12 = PickRow(mapped, 22),
        };

        foreach (var a in named)
            a();
    }

    private static List<ReportMainItem> PickRow(List<List<ReportMainItem>> mapped, int index) =>
        index < mapped.Count ? mapped[index] : new List<ReportMainItem>();
}
