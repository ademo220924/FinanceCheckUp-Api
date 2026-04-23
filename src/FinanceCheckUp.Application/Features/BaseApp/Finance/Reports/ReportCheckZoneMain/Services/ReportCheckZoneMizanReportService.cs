using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.CrossTab;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.ViewModel;
using CompanyEntity = FinanceCheckUp.Domain.Entities.Company;
using fincheckup.Report;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Services;

public sealed class ReportCheckZoneMizanReportService(
    ICompanyManager companyManager,
    IMainDashManager mainDashManager,
    IHhvnUsersManager hhvnUsersManager,
    IMizanFinancialNarrativeService narrativeService)
    : IReportCheckZoneMizanReportService
{
    private const int MizanCsvType = 3;

    public DynamicReport GetReportMizan(long companyId, string nacceco, long userId, List<int> nyearChkList, string ncccode) =>
        BuildMizanDynamicReport(companyId, nacceco, userId, nyearChkList, ncccode, trimFourYearWindow: false);

    public DynamicReportfour GetReportMizanFour(long companyId, string nacceco, long userId, List<int> nyearChkList, string ncccode) =>
        BuildMizanDynamicReportFour(companyId, nacceco, userId, nyearChkList, ncccode);

    private DynamicReportfour BuildMizanDynamicReportFour(
        long companyId,
        string nacceco,
        long userId,
        List<int> nyearChkList,
        string ncccode)
    {
        var ctx = BuildMizanContext(companyId, nacceco, userId, nyearChkList, ncccode, trimFourYearWindow: true);
        var report = new DynamicReportfour(ctx.RiskData, ctx.RdColor);
        WireMizanXtraReport(report, ctx, checkSize: null);
        return report;
    }

    private DynamicReport BuildMizanDynamicReport(
        long companyId,
        string nacceco,
        long userId,
        List<int> nyearChkList,
        string ncccode,
        bool trimFourYearWindow)
    {
        var ctx = BuildMizanContext(companyId, nacceco, userId, nyearChkList, ncccode, trimFourYearWindow);
        var report = new DynamicReport(ctx.RiskData, ctx.RdColor);
        report.CheckSize = ctx.YearCount;
        WireMizanXtraReport(report, ctx, checkSize: ctx.YearCount);
        return report;
    }

    private MizanReportContext BuildMizanContext(
        long companyId,
        string nacceco,
        long userId,
        List<int> nyearChkList,
        string ncccode,
        bool trimFourYearWindow)
    {
        if (nyearChkList == null || nyearChkList.Count == 0)
            throw new ArgumentException("Yıl listesi boş olamaz.", nameof(nyearChkList));

        companyManager.DataReportMainNace(ncccode, companyId);

        var years = new List<int>(nyearChkList);
        int nyear_;
        int[] nyearListmain;
        int yearCount;

        if (trimFourYearWindow)
        {
            years.Reverse();
            if (years.Count > 4)
                years = years.Take(4).ToList();
            nyear_ = years.Max();
            yearCount = years.Count;
            years.Sort();
            nyearListmain = years.ToArray();
        }
        else
        {
            years.Sort();
            nyearListmain = years.ToArray();
            nyear_ = nyearListmain.Max();
            yearCount = years.Count;
        }

        var nnlist = companyManager.Get_CompanyReportYearMainMizanReport(companyId);
        if (trimFourYearWindow)
        {
            nnlist = nnlist.OrderByDescending(x => x).Take(4).ToList();
        }

        IEnumerable<CsvDynamic>? csv1 = null;
        IEnumerable<CsvDynamicII>? csv2 = null;
        IEnumerable<CsvDynamicIII>? csv3 = null;
        IEnumerable<CsvDynamicIIII>? csv4 = null;

        switch (nnlist.Count)
        {
            case 1: csv1 = companyManager.GetCompanyReportCsv(companyId, MizanCsvType); break;
            case 2: csv2 = companyManager.GetCompanyReportCsvII(companyId, MizanCsvType); break;
            case 3: csv3 = companyManager.GetCompanyReportCsvIII(companyId, MizanCsvType); break;
            case 4: csv4 = companyManager.GetCompanyReportCsvIIII(companyId, MizanCsvType); break;
        }

        nnlist.Sort();
        var nname = Guid.NewGuid().ToString("D") + ".csv";
        var filePath = global::System.IO.Path.Combine(WebHelper.path, "wwwroot", "FileContent", nname);
        global::System.IO.Directory.CreateDirectory(global::System.IO.Path.GetDirectoryName(filePath)!);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };
        using (var writer = new global::System.IO.StreamWriter(filePath, append: true))
        using (var csv = new CsvWriter(writer, config))
        {
            switch (nnlist.Count)
            {
                case 1: if (csv1 != null) csv.WriteRecords(csv1); break;
                case 2: if (csv2 != null) csv.WriteRecords(csv2); break;
                case 3: if (csv3 != null) csv.WriteRecords(csv3); break;
                case 4: if (csv4 != null) csv.WriteRecords(csv4); break;
            }
        }

        var headerRow = "Hesap;" + string.Join(";", nnlist);
        var replacenull = headerRow + global::System.IO.File.ReadAllText(filePath);
        replacenull = replacenull.Replace("null", "").Replace("\r\n", "\t");

        var retvalue = narrativeService.GetMizanNarrativeAsync(replacenull).GetAwaiter().GetResult();
        retvalue = NormalizeNarrative(retvalue);

        var mreqListCompany = companyManager.Getby_User(userId).ToList();
        var cCompany = mreqListCompany.FirstOrDefault(x => x.IsDefault == 1)
                       ?? throw new InvalidOperationException("Kullanıcı için varsayılan şirket bulunamadı.");

        var effectiveCompanyId = cCompany.Id;
        var compNace = ParseNaceDigits(cCompany.NaceCode);

        _ = hhvnUsersManager.GetRow_User(userId);

        var checkedData = mainDashManager.DataReportMainKapakDynamic(nyear_, effectiveCompanyId).ToList();
        var riskdatachk = RiskData.GetListedPoint(checkedData);
        var riskdata = RiskData.GetPoint(riskdatachk);
        var ncheckKapak = ReportKapak.setKapak(checkedData) ?? new ReportKapak();

        var ncheck = mainDashManager.DataReportMainDynamic(nyearListmain, effectiveCompanyId);
        var nchecka = mainDashManager.DataReportMainADynamic(nyearListmain, effectiveCompanyId);
        var ncheck1 = mainDashManager.DataReportMainBDynamic(nyearListmain, effectiveCompanyId);
        var ncheck1a = mainDashManager.DataReportMainCDynamic(nyearListmain, effectiveCompanyId);
        var ncheckd = mainDashManager.DataReportMainDDynamic(nyearListmain, effectiveCompanyId);
        var nchecke = mainDashManager.DataReportMainEDynamic(nyearListmain, effectiveCompanyId);
        var ncheckf = mainDashManager.DataReportMainFDynamic(nyearListmain, effectiveCompanyId);
        var ncheckg = mainDashManager.DataReportMainGDynamic(nyearListmain, effectiveCompanyId);
        var nchecklast = mainDashManager.DataReportMainTDynamic(nyearListmain, effectiveCompanyId);

        var ncheckb = ncheck.Where(x => x.CounterZone == 11).ToList();
        var ncheckchart = mainDashManager.DataReportMainChartMainMulti(ncheckb.OrderBy(x => x.Year));
        var ncheckc = ncheck.Where(x => x.CounterZone == 1011).ToList();
        var ncheckchartb = mainDashManager.DataReportMainChartMainMulti(ncheckc.OrderBy(x => x.Year));

        var rdColor = new RiskDataColor();
        var ncheck1_ = mainDashManager.DataReportMain1Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck2 = mainDashManager.DataReportMain2Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck3 = mainDashManager.DataReportMain3Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck4 = mainDashManager.DataReportMain4Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck5 = mainDashManager.DataReportMain5Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck6 = mainDashManager.DataReportMain6Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck7 = mainDashManager.DataReportMain7Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck8 = mainDashManager.DataReportMain8Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck9 = mainDashManager.DataReportMain9Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck10 = mainDashManager.DataReportMain10Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck11 = mainDashManager.DataReportMain11Dynamic(nyearListmain, effectiveCompanyId, compNace);
        var ncheck12 = mainDashManager.DataReportMain12Dynamic(nyearListmain, effectiveCompanyId, compNace);

        RiskDataColor.GetListedPoint(ncheck1_, 1, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck2, 2, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck3, 3, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck4, 4, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck5, 5, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck6, 6, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck7, 7, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck8, 8, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck9, 9, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck10, 10, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck11, 11, false, rdColor);
        RiskDataColor.GetListedPoint(ncheck12, 12, false, rdColor);

        var ncheckchart1 = mainDashManager.DataReportMainChartMainMulti(ncheck1_.OrderBy(x => x.Year));
        var ncheckchart2 = mainDashManager.DataReportMainChartMainMulti(ncheck2.OrderBy(x => x.Year));
        var ncheckchart3 = mainDashManager.DataReportMainChartMainMulti(ncheck3.OrderBy(x => x.Year));
        var ncheckchart4 = mainDashManager.DataReportMainChartMainMulti(ncheck4.OrderBy(x => x.Year));
        var ncheckchart5 = mainDashManager.DataReportMainChartMainMulti(ncheck5.OrderBy(x => x.Year));
        var ncheckchart6 = mainDashManager.DataReportMainChartMainMulti(ncheck6.OrderBy(x => x.Year));
        var ncheckchart7 = mainDashManager.DataReportMainChartMainMulti(ncheck7.OrderBy(x => x.Year));
        var ncheckchart8 = mainDashManager.DataReportMainChartMainMulti(ncheck8.OrderBy(x => x.Year));
        var ncheckchart9 = mainDashManager.DataReportMainChartMainMulti(ncheck9.OrderBy(x => x.Year));
        var ncheckchart10 = mainDashManager.DataReportMainChartMainMulti(ncheck10.OrderBy(x => x.Year));
        var ncheckchart11 = mainDashManager.DataReportMainChartMainMulti(ncheck11.OrderBy(x => x.Year));
        var ncheckchart12 = mainDashManager.DataReportMainChartMainMulti(ncheck12.OrderBy(x => x.Year));

        try
        {
            global::System.IO.File.Delete(filePath);
        }
        catch
        {
            // geçici csv — silinemezse akışı durdurmayız
        }

        return new MizanReportContext(
            riskdata,
            rdColor,
            ncheckKapak,
            cCompany,
            retvalue,
            yearCount,
            ncheck,
            nchecka,
            ncheck1,
            ncheck1a,
            ncheckd,
            nchecke,
            ncheckf,
            ncheckg,
            nchecklast,
            ncheck1_,
            ncheck2,
            ncheck3,
            ncheck4,
            ncheck5,
            ncheck6,
            ncheck7,
            ncheck8,
            ncheck9,
            ncheck10,
            ncheck11,
            ncheck12,
            ncheckchart,
            ncheckchartb,
            ncheckchart1,
            ncheckchart2,
            ncheckchart3,
            ncheckchart4,
            ncheckchart5,
            ncheckchart6,
            ncheckchart7,
            ncheckchart8,
            ncheckchart9,
            ncheckchart10,
            ncheckchart11,
            ncheckchart12);
    }

    private static int ParseNaceDigits(string? naceCode)
    {
        if (string.IsNullOrWhiteSpace(naceCode))
            return 2790;
        var digits = naceCode.Replace(".", "", StringComparison.Ordinal);
        if (digits.Length >= 4)
            return int.Parse(digits[..4], CultureInfo.InvariantCulture);
        if (digits.Length >= 3)
            return int.Parse(digits[..3], CultureInfo.InvariantCulture);
        return 2790;
    }

    private static string NormalizeNarrative(string retvalue)
    {
        var vall = retvalue.IndexOf("Dönen Varlıklar", StringComparison.Ordinal);
        if (vall < 0)
            vall = 0;
        retvalue = retvalue[vall..];
        vall = retvalue.IndexOf("**Varlıklar**", StringComparison.Ordinal);
        if (vall < 0)
            vall = 0;
        retvalue = retvalue[vall..];
        return retvalue.Replace("**", "", StringComparison.Ordinal).Replace("#", "", StringComparison.Ordinal)
            .Replace("-", "", StringComparison.Ordinal);
    }

    private static void WireMizanXtraReport(XtraReport report, MizanReportContext ctx, int? checkSize)
    {
        var checkSeries = new LineSeriesView();

        var ds = new ObjectDataSource { Name = "DataViewer", DataSource = ctx.Ncheck };
        ds.Fill();
        var dsA = new ObjectDataSource { Name = "DataViewerA", DataSource = ctx.Nchecka };
        dsA.Fill();
        var dsB = new ObjectDataSource { Name = "DataViewerB", DataSource = ctx.Ncheck1 };
        dsB.Fill();
        var dsC = new ObjectDataSource { Name = "DataViewerC", DataSource = ctx.Ncheck1a };
        dsC.Fill();
        var dsD = new ObjectDataSource { Name = "DataViewerD", DataSource = ctx.Ncheckd };
        dsD.Fill();
        var dsE = new ObjectDataSource { Name = "DataViewerE", DataSource = ctx.Nchecke };
        dsE.Fill();
        var dsF = new ObjectDataSource { Name = "DataViewerF", DataSource = ctx.Ncheckf };
        dsF.Fill();
        var dsG = new ObjectDataSource { Name = "DataViewerG", DataSource = ctx.Ncheckg };
        dsG.Fill();
        var dsT = new ObjectDataSource { Name = "DataViewerT", DataSource = ctx.Nchecklast };
        dsT.Fill();

        SetCrossTabDataSource(report, "xrCrossTab1", ds);
        SetCrossTabDataSource(report, "xrCrossTab2", dsA);
        SetCrossTabDataSource(report, "xrCrossTabBilancoGenel", dsB);
        SetCrossTabDataSource(report, "xrCrossTabYukumluuk", dsC);
        SetCrossTabDataSource(report, "xrCrossTabKarlk", dsD);
        SetCrossTabDataSource(report, "xrCrossTabBorcOdeme", dsE);
        SetCrossTabDataSource(report, "xrCrossTabLikidite", dsF);
        SetCrossTabDataSource(report, "xrCrossTabSermaye", dsG);
        SetCrossTabDataSource(report, "xrCrossTabRasio", dsT);

        SetCrossTabListSource(report, "xrCrossTabBnkYabKynk", ctx.Ncheck1_);
        SetCrossTabListSource(report, "xrCrossTabBnkAktif", ctx.Ncheck2);
        SetCrossTabListSource(report, "xrCrossTabDuranOkynk", ctx.Ncheck3);
        SetCrossTabListSource(report, "xrCrossTabDonenAktif", ctx.Ncheck4);
        SetCrossTabListSource(report, "xrCrossTabKVAktif", ctx.Ncheck5);
        SetCrossTabListSource(report, "xrCrossTabKVDonen", ctx.Ncheck6);
        SetCrossTabListSource(report, "xrCrossTabKVPasif", ctx.Ncheck7);
        SetCrossTabListSource(report, "xrCrossTabMaddiOzkaynak", ctx.Ncheck8);
        SetCrossTabListSource(report, "xrCrossTabStokAktif", ctx.Ncheck9);
        SetCrossTabListSource(report, "xrCrossTabUVadePasif", ctx.Ncheck10);
        SetCrossTabListSource(report, "xrCrossTabOKynkYbKyn", ctx.Ncheck11);
        SetCrossTabListSource(report, "xrCrossTabOKynkAktif", ctx.Ncheck12);

        if (report.FindControl("xrChart1", false) is XRChart chart)
        {
            chart.Series.Clear();
            chart.DataSource = ctx.Ncheckchart;
            chart.SeriesTemplate.SeriesDataMember = "GroupName";
            chart.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");
        }

        if (report.FindControl("xrChart2", false) is XRChart chart1)
        {
            chart1.Series.Clear();
            chart1.DataSource = ctx.Ncheckchartb;
            chart1.SeriesTemplate.SeriesDataMember = "GroupName";
            chart1.SeriesTemplate.Label.TextPattern = "{V:n2}";
            chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
            chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");
        }

        BindSectorChart(report, "xrChartBnkYabKynk", ctx.Ncheckchart1, checkSeries);
        BindSectorChart(report, "xrChartBnkAktif", ctx.Ncheckchart2, checkSeries);
        BindSectorChart(report, "xrChartDuranOkynk", ctx.Ncheckchart3, checkSeries);
        BindSectorChart(report, "xrChartDonenAktif", ctx.Ncheckchart4, checkSeries);
        BindSectorChart(report, "xrChartKVAktif", ctx.Ncheckchart5, checkSeries);
        BindSectorChart(report, "xrChartKVDonen", ctx.Ncheckchart6, checkSeries);
        BindSectorChart(report, "xrChartKVPasif", ctx.Ncheckchart7, checkSeries);
        BindSectorChart(report, "xrChartMaddiOzkaynak", ctx.Ncheckchart8, checkSeries);
        BindSectorChart(report, "xrChartStokAktif", ctx.Ncheckchart9, checkSeries);
        BindSectorChart(report, "xrChartUVadePasif", ctx.Ncheckchart10, checkSeries);
        BindSectorChart(report, "xrChartOKynkYbKyn", ctx.Ncheckchart11, checkSeries);
        BindSectorChart(report, "xrChartOKynkAktif", ctx.Ncheckchart12, checkSeries);

        if (report.FindControl("xrLblOzkaynak", true) is XRLabel l1)
            l1.Text = ctx.NcheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2", CultureInfo.InvariantCulture);
        if (report.FindControl("xrlblCarioran", true) is XRLabel l2)
            l2.Text = ctx.NcheckKapak.nitemCariOran.TumYil.ToString("N2", CultureInfo.InvariantCulture);
        if (report.FindControl("xrlblROA", true) is XRLabel l3)
            l3.Text = (ctx.NcheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2", CultureInfo.InvariantCulture) + "%";
        if (report.FindControl("xrlblAltmanZ", true) is XRLabel l4)
            l4.Text = ctx.NcheckKapak.nitemAltmanz.TumYil.ToString("N2", CultureInfo.InvariantCulture);
        if (report.FindControl("xrlblNetIsletmeSerm", true) is XRLabel l5)
            l5.Text = ctx.NcheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0", CultureInfo.InvariantCulture);
        if (report.FindControl("xrlblFaizVeVergi", true) is XRLabel l6)
            l6.Text = ctx.NcheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2", CultureInfo.InvariantCulture);

        if (report.FindControl("xrLabelCompanyName", true) is XRLabel cn)
            cn.Text = ctx.Company.CompanyName ?? string.Empty;
        if (report.FindControl("xrLabelCompanyAdress", true) is XRLabel ad)
            ad.Text = ctx.Company.Adress ?? string.Empty;
        if (report.FindControl("xrLabelCompanyNace", true) is XRLabel nc)
            nc.Text = ctx.Company.NaceCode ?? string.Empty;

        if (report.FindControl("xrRichTextAnaMetin", true) is XRRichText rt)
            rt.Rtf = ctx.NarrativeRtf;

        report.PrintingSystem.Document.Name = "Balance_raporlar";

        if (checkSize.HasValue && report is DynamicReport dr)
            dr.CheckSize = checkSize.Value;
    }

    private static void SetCrossTabDataSource(XtraReport report, string controlName, ObjectDataSource ds)
    {
        if (report.FindControl(controlName, true) is XRCrossTab ct)
            ct.DataSource = ds;
    }

    private static void SetCrossTabListSource(XtraReport report, string controlName, List<ReportMainItem> list)
    {
        if (report.FindControl(controlName, true) is XRCrossTab ct)
            ct.DataSource = list;
    }

    private static void BindSectorChart(XtraReport report, string chartName, List<ReportMainChart> data, LineSeriesView view)
    {
        if (report.FindControl(chartName, false) is not XRChart c)
            return;
        c.SeriesTemplate.View = view;
        c.DataSource = data;
        c.SeriesTemplate.SeriesDataMember = "GroupName";
        c.SeriesTemplate.Label.TextPattern = "{V:n2}";
        c.SeriesTemplate.ArgumentDataMember = "GroupText";
        c.SeriesTemplate.ValueDataMembers.AddRange("Value");
        c.PaletteName = "PaletteDyn";
        c.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
    }

    private sealed record MizanReportContext(
        RiskData RiskData,
        RiskDataColor RdColor,
        ReportKapak NcheckKapak,
        CompanyEntity Company,
        string NarrativeRtf,
        int YearCount,
        List<ReportMainItem> Ncheck,
        List<ReportMainItem> Nchecka,
        List<ReportMainItem> Ncheck1,
        List<ReportMainItem> Ncheck1a,
        List<ReportMainItem> Ncheckd,
        List<ReportMainItem> Nchecke,
        List<ReportMainItem> Ncheckf,
        List<ReportMainItem> Ncheckg,
        List<ReportMainItem> Nchecklast,
        List<ReportMainItem> Ncheck1_,
        List<ReportMainItem> Ncheck2,
        List<ReportMainItem> Ncheck3,
        List<ReportMainItem> Ncheck4,
        List<ReportMainItem> Ncheck5,
        List<ReportMainItem> Ncheck6,
        List<ReportMainItem> Ncheck7,
        List<ReportMainItem> Ncheck8,
        List<ReportMainItem> Ncheck9,
        List<ReportMainItem> Ncheck10,
        List<ReportMainItem> Ncheck11,
        List<ReportMainItem> Ncheck12,
        List<ReportMainChart> Ncheckchart,
        List<ReportMainChart> Ncheckchartb,
        List<ReportMainChart> Ncheckchart1,
        List<ReportMainChart> Ncheckchart2,
        List<ReportMainChart> Ncheckchart3,
        List<ReportMainChart> Ncheckchart4,
        List<ReportMainChart> Ncheckchart5,
        List<ReportMainChart> Ncheckchart6,
        List<ReportMainChart> Ncheckchart7,
        List<ReportMainChart> Ncheckchart8,
        List<ReportMainChart> Ncheckchart9,
        List<ReportMainChart> Ncheckchart10,
        List<ReportMainChart> Ncheckchart11,
        List<ReportMainChart> Ncheckchart12);
}
