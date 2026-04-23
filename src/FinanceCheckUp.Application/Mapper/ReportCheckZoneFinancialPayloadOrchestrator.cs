using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using fincheckup.Report;

namespace FinanceCheckUp.Application.Mapper;

/// <summary>
/// IReportCheckZoneManager raporlarını API DTO&apos;suna çevirir.
/// </summary>
internal static class ReportCheckZoneFinancialPayloadOrchestrator
{
    public static FinancialReportZonePayloadResponse BuildFromGetReport(
        IReportCheckZoneManager zone,
        ICompanyManager companies,
        ReportCheckZoneMainWithYearListRequest req)
    {
        var nyearList = req.NyearList ?? new List<int>();
        if (nyearList.Count == 0)
            throw new ArgumentException("NyearList boş olamaz.");

        var grview = companies.Get_CompanyReportView(req.CompanyId);
        var lastYear = nyearList[^1];

        using var report = zone.getReport(req.CompanyId, nyearList, req.Nacceco, (int)req.UserId, lastYear, grview);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }

    public static FinancialReportZonePayloadResponse BuildFromGetReportOldMII(
        IReportCheckZoneManager zone,
        ICompanyManager companies,
        ReportCheckZoneoldStandardRequest req)
    {
        var years = req.NyearChkList ?? new List<int>();
        if (years.Count == 0)
            throw new ArgumentException("NyearChkList boş olamaz.");

        var grview = companies.Get_CompanyReportView(req.CompanyId);
        var lastYear = years[^1];

        using var report = zone.getReport(req.CompanyId, years, req.Nacceco, (int)req.UserId, lastYear, grview);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }

    public static FinancialReportZonePayloadResponse BuildFromGetReportA(
        IReportCheckZoneManager zone,
        ICompanyManager companies,
        List<int> nyear,
        List<int> nyearChkList,
        string nacceco,
        long companyId,
        long userId)
    {
        if (nyearChkList == null || nyearChkList.Count < 2)
            throw new ArgumentException("getReporta için NyearChkList en az 2 yıl içermelidir.");

        nyear ??= nyearChkList;
        var grview = companies.Get_CompanyReportView(companyId);

        using var report = zone.getReporta(companyId, nyear, nacceco, (int)userId, nyearChkList, grview);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }

    public static FinancialReportZonePayloadResponse BuildFromGetReportB(
        IReportCheckZoneManager zone,
        ICompanyManager companies,
        List<int> nyear,
        List<int> nyearChkList,
        string nacceco,
        long companyId,
        long userId)
    {
        if (nyearChkList == null || nyearChkList.Count < 3)
            throw new ArgumentException("getReportb için NyearChkList en az 3 yıl içermelidir.");

        nyear ??= nyearChkList;
        var grview = companies.Get_CompanyReportView(companyId);

        using var report = zone.getReportb(companyId, nyear, nacceco, (int)userId, nyearChkList, grview);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }

    public static FinancialReportZonePayloadResponse BuildFromGetReportC(
        IReportCheckZoneManager zone,
        ICompanyManager companies,
        List<int> nyear,
        List<int> nyearChkList,
        string nacceco,
        long companyId,
        long userId)
    {
        if (nyearChkList == null || nyearChkList.Count < 4)
            throw new ArgumentException("getReportc için NyearChkList en az 4 yıl içermelidir.");

        nyear ??= nyearChkList;
        var grview = companies.Get_CompanyReportView(companyId);

        using var report = zone.getReportc(companyId, nyear, nacceco, (int)userId, nyearChkList, grview);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }

    /// <summary>
    /// Web <c>ReportCheckZoneMain.getReportMizan</c> — QNB <see cref="FinansRaporua"/> değil, <see cref="DynamicReport"/>.
    /// </summary>
    public static FinancialReportZonePayloadResponse BuildFromGetReportMizan(
        IReportCheckZoneManager zone,
        List<int> nyearChkList,
        string nacceco,
        string ncccode,
        long companyId,
        long userId)
    {
        var years = nyearChkList ?? new List<int>();
        if (years.Count == 0)
            throw new ArgumentException("NyearChkList boş olamaz.");

        using DynamicReport report = zone.getReportMizan(companyId, nacceco, userId, years, ncccode);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }

    /// <summary>
    /// Web <c>ReportCheckZoneMain.getReportMizanFour</c> — QNB <see cref="FinansRaporub"/> değil, <see cref="DynamicReportfour"/>.
    /// </summary>
    public static FinancialReportZonePayloadResponse BuildFromGetReportMizanFour(
        IReportCheckZoneManager zone,
        List<int> nyearChkList,
        string nacceco,
        string ncccode,
        long companyId,
        long userId)
    {
        var years = nyearChkList ?? new List<int>();
        if (years.Count == 0)
            throw new ArgumentException("NyearChkList boş olamaz.");

        using DynamicReportfour report = zone.getReportMizanFour(companyId, nacceco, userId, years, ncccode);
        return FinansRaporZonePayloadExtractor.FromXtraReport(report);
    }
}
