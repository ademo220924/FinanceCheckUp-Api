using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Responses.ReportApis;

public class ReportGetListResponse
{
    public List<DataViewer> EntryData { get; set; }
}