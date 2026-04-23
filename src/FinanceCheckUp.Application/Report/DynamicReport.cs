using System.Globalization;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.CrossTab;
using System.Drawing;
using FinanceCheckUp.Application.Models.ViewModel;

namespace fincheckup.Report;

public partial class DynamicReport : XtraReport
{
    public DynamicReport(RiskData datachk, RiskDataColor rdColor)
    {
        InitializeComponent();
        FillReportData(datachk, rdColor);
    }

    private void FillReportData(RiskData data, RiskDataColor rdColor)
    {
        FillCariRates(data.CariRate, "xrRisk", "xrCariOranLabel", data.CariRatePoint);
        FillCariRates(data.TotalDebttoEquityRatio, "xrToplamBorc", "xrToplamBorcLabel", data.TotalDebttoEquityRatioPoint);
        FillCariRates(data.LiquidityRatio, "xrLikidite", "xrLikiditeLabel", data.LiquidityRatioPoint);
        FillCariRates(data.TotalDebttoEquityRatio, "xrDevirHizi", "xrDevirHiziLabel", data.TotalDebttoEquityRatioPoint);
        FillCariRates(data.CashAssetRatio, "xrNakit", "xrNakitLabel", data.CashAssetRatioPoint);
        FillCariRates(data.Equity, "xrAktif", "xrAktifLabel", data.EquityPoint);

        FillSektorelRates(rdColor.ncheck1, "xrCellBnkYabKynk", rdColor.ncheck1Point);
        FillSektorelRates(rdColor.ncheck2, "xrCellBnkAktif", rdColor.ncheck2Point);
        FillSektorelRates(rdColor.ncheck3, "xrCellDuranOkynk", rdColor.ncheck3Point);
        FillSektorelRates(rdColor.ncheck4, "xrCellDonenAktif", rdColor.ncheck4Point);
        FillSektorelRates(rdColor.ncheck5, "xrCellKVAktif", rdColor.ncheck5Point);
        FillSektorelRates(rdColor.ncheck6, "xrCellKVDonen", rdColor.ncheck6Point);

        FillSektorelRates(rdColor.ncheck7, "xrCellKVPasif", rdColor.ncheck7Point);
        FillSektorelRates(rdColor.ncheck8, "xrCellMaddiOzkaynak", rdColor.ncheck8Point);
        FillSektorelRates(rdColor.ncheck9, "xrCellStokAktif", rdColor.ncheck9Point);
        FillSektorelRates(rdColor.ncheck10, "xrCellUVadePasif", rdColor.ncheck10Point);
        FillSektorelRates(rdColor.ncheck11, "xrCellOKynkYbKyn", rdColor.ncheck11Point);
        FillSektorelRates(rdColor.ncheck12, "xrCellOKynkAktif", rdColor.ncheck12Point);
    }

    private void FillCariRates(float ratio, string id, string labelId, int ratioPoint)
    {
        XRShape? lastShape = null;
        for (var i = 1; i <= ratioPoint; i++)
        {
            if (i > 7)
                break;

            if (Report.FindControl(id + i, true) is not XRShape shape1)
                continue;
            shape1.FillColor = CheckColor(i);
            lastShape = shape1;
        }

        if (Report.FindControl(labelId, true) is not XRLabel label || lastShape == null)
            return;

        label.LocationF = new PointF(lastShape.LocationF.X, lastShape.LocationF.Y);
        label.Text = ratio == 0 ? ratio.ToString("n0", CultureInfo.InvariantCulture) : ratio.ToString("n2", CultureInfo.InvariantCulture);
        label.BringToFront();
    }

    private void FillSektorelRates(float ratio, string id, int ratioPoint)
    {
        if (Report.FindControl(id + ratioPoint, true) is not XRTableCell shape1)
            return;
        shape1.BackColor = CheckColorSektorel(ratioPoint);
        shape1.Text = ratio == 0 ? ratio.ToString("n0", CultureInfo.InvariantCulture) : ratio.ToString("n2", CultureInfo.InvariantCulture);
    }

    public Color CheckColor(int colorpoint) => colorpoint switch
    {
        1 => Color.FromArgb(45, 165, 84),
        2 => Color.FromArgb(88, 182, 75),
        3 => Color.FromArgb(190, 214, 58),
        4 => Color.FromArgb(242, 169, 42),
        5 => Color.FromArgb(234, 117, 44),
        6 => Color.FromArgb(227, 46, 44),
        7 => Color.FromArgb(169, 32, 28),
        _ => Color.Empty
    };

    public Color CheckColorSektorel(int colorpoint) => colorpoint switch
    {
        1 => Color.FromArgb(88, 183, 75),
        2 => Color.FromArgb(189, 214, 58),
        3 => Color.FromArgb(242, 168, 43),
        4 => Color.FromArgb(229, 113, 43),
        5 => Color.FromArgb(230, 52, 43),
        _ => Color.Empty
    };

    public int CheckSize { get; set; }

    private void xrCrossTab1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (CheckSize == 1)
        {
            crossTabHeaderCellMain.WidthF = 529;
            xrCrossTabCell4Main.WidthF = 529;
        }
        else if (CheckSize == 2)
        {
            crossTabHeaderCellMain.WidthF = 415;
            xrCrossTabCell4Main.WidthF = 415;
        }
        else if (CheckSize >= 3)
        {
            crossTabHeaderCellMain.WidthF = 243;
            xrCrossTabCell4Main.WidthF = 243;
        }

        if (sender is XRCrossTab crossTab)
        {
            _ = crossTab.RootReport.PageWidth - crossTab.RootReport.Margins.Left - crossTab.RootReport.Margins.Right -
                crossTab.LocationF.X;
        }
    }

    private void xrChart3_BoundDataChanged(object sender, EventArgs e)
    {
    }
}
