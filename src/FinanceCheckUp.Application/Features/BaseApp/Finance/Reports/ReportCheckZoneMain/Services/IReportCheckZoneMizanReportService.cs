using fincheckup.Report;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Services;

/// <summary>
/// Web <c>fincheckup.Helper.Report.ReportCheckZoneMain</c> mizan raporları (<see cref="DynamicReport"/>, <see cref="DynamicReportfour"/>).
/// </summary>
public interface IReportCheckZoneMizanReportService
{
    DynamicReport GetReportMizan(long companyId, string nacceco, long userId, List<int> nyearChkList, string ncccode);

    DynamicReportfour GetReportMizanFour(long companyId, string nacceco, long userId, List<int> nyearChkList, string ncccode);
}
