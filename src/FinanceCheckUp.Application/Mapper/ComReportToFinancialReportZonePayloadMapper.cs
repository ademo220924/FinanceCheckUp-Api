using System.Drawing;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;

namespace FinanceCheckUp.Application.Mapper;

internal static class ComReportToFinancialReportZonePayloadMapper
{
    public static FinancialReportZonePayloadResponse Map(ComReport c)
    {
        return new FinancialReportZonePayloadResponse
        {
            Ncheck = c.ncheck,
            NcheckLast = c.nchecklast,
            NcheckA = c.nchecka,
            Ncheck1 = c.ncheck1,
            Ncheck1a = c.ncheck1a,
            NcheckB = c.ncheckb,
            NcheckC = c.ncheckc,
            NcheckD = c.ncheckd,
            NcheckE = c.nchecke,
            NcheckF = c.ncheckf,
            NcheckG = c.ncheckg,
            Ncheck1Underscore = c.ncheck1_,
            Ncheck2 = c.ncheck2,
            Ncheck3 = c.ncheck3,
            Ncheck4 = c.ncheck4,
            Ncheck5 = c.ncheck5,
            Ncheck6 = c.ncheck6,
            Ncheck7 = c.ncheck7,
            Ncheck8 = c.ncheck8,
            Ncheck9 = c.ncheck9,
            Ncheck10 = c.ncheck10,
            Ncheck11 = c.ncheck11,
            Ncheck12 = c.ncheck12,
            NcheckKapak = c.ncheckKapak,
            ShapeArgb1 = ToArgb(c.shape1),
            ShapeArgb2 = ToArgb(c.shape2),
            ShapeArgb3 = ToArgb(c.shape3),
            ShapeArgb4 = ToArgb(c.shape4),
            ShapeArgb5 = ToArgb(c.shape5),
            ShapeArgb6 = ToArgb(c.shape6),
            ShapeArgb7 = ToArgb(c.shape7),
            ShapeArgb8 = ToArgb(c.shape8),
            ShapeArgb9 = ToArgb(c.shape9),
            NcheckChart = c.ncheckchart,
            NcheckChartB = c.ncheckchartb,
            NcheckChart1 = c.ncheckchart1,
            NcheckChart2 = c.ncheckchart2,
            NcheckChart3 = c.ncheckchart3,
            NcheckChart4 = c.ncheckchart4,
            NcheckChart5 = c.ncheckchart5,
            NcheckChart6 = c.ncheckchart6,
            NcheckChart7 = c.ncheckchart7,
            NcheckChart8 = c.ncheckchart8,
            NcheckChart9 = c.ncheckchart9,
            NcheckChart10 = c.ncheckchart10,
            NcheckChart11 = c.ncheckchart11,
            NcheckChart12 = c.ncheckchart12,
            CompNaceCode = c.compnacecode,
            Repchakec = c.repchakec,
            Header = c.header,
            Nccode = c.nccode
        };
    }

    private static int? ToArgb(Color color)
    {
        return color.IsEmpty ? null : color.ToArgb();
    }
}
