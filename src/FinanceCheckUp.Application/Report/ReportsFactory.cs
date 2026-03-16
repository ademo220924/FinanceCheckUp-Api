using DevExpress.XtraReports.UI;

namespace fincheckup.Report
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["TestReport"] = () => new KontrolRaporu()
        };
    }
}
