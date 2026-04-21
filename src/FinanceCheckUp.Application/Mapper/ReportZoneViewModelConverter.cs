using FinanceCheckUp.Application.Models.ViewModel;

namespace FinanceCheckUp.Application.Mapper;

internal static class ReportZoneViewModelConverter
{
    public static ReportMainItem? FromQnb(ReportMainItemQnb x)
    {
        if (x == null) return null;
        return new ReportMainItem
        {
            Q1 = x.Amount,
            Q2 = x.Amount1,
            Q3 = x.Amount2,
            TumYil = x.Amount3 != 0 ? x.Amount3 : x.Amount4,
            CompanyID = x.CompanyID,
            Year = x.Year,
            GroupName = x.GroupName ?? string.Empty,
            CounterZone = x.CounterZone,
            TypeID = x.TypeID,
        };
    }

    public static List<ReportMainItem> FromQnbList(IEnumerable<ReportMainItemQnb> list) =>
        list?.Select(x => FromQnb(x)).Where(x => x != null).Cast<ReportMainItem>().ToList() ?? new List<ReportMainItem>();

    public static ReportMainItem? FromDash(DashBilancoViewQnb x)
    {
        if (x == null) return null;
        return new ReportMainItem
        {
            Q1 = (float)x.Amount,
            Q2 = (float)x.Amount1,
            Q3 = (float)x.Amount2,
            TumYil = (float)x.Amount3,
            CompanyID = x.CompanyID,
            Year = x.Year,
            GroupName = x.GroupName ?? string.Empty,
            CounterZone = x.CounterZone,
            TypeID = x.TypeID,
        };
    }

    public static List<ReportMainItem> FromDashList(IEnumerable<DashBilancoViewQnb> list) =>
        list?.Select(x => FromDash(x)).Where(x => x != null).Cast<ReportMainItem>().ToList() ?? new List<ReportMainItem>();

    public static ReportMainChart? FromChartQnb(ReportMainChartQnb? x)
    {
        if (x == null) return null;
        return new ReportMainChart
        {
            GroupName = x.GridName ?? x.AccountMainID ?? string.Empty,
            GroupText = x.GroupText ?? string.Empty,
            Value = x.Amount
        };
    }

    public static List<ReportMainChart> FromChartQnbList(IEnumerable<ReportMainChartQnb> list) =>
        list?.Select(FromChartQnb).Where(x => x != null).Cast<ReportMainChart>().ToList() ?? new List<ReportMainChart>();

    /// <summary>Bilinmeyen satır türlerini tek kolonla taşır.</summary>
    public static List<ReportMainItem> FromObjectList(IEnumerable<object> list)
    {
        var r = new List<ReportMainItem>();
        if (list == null) return r;
        foreach (var o in list)
        {
            switch (o)
            {
                case ReportMainItemQnb q:
                    r.Add(FromQnb(q)!);
                    break;
                case DashBilancoViewQnb d:
                    r.Add(FromDash(d)!);
                    break;
                case ReportMainItem m:
                    r.Add(m);
                    break;
                default:
                    r.Add(new ReportMainItem { GroupName = o?.ToString() ?? string.Empty });
                    break;
            }
        }
        return r;
    }
}
