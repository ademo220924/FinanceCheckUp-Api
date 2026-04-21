namespace FinanceCheckUp.Application.Models.Requests.Finance.Reports;

public class ReportCheckZoneMainWithYearListRequest
{
    public long CompanyId { get; set; }
    public List<int> NyearList { get; set; }
    public string Nacceco { get; set; }
    public long UserId { get; set; }
    public List<int> NyearChkList { get; set; }
    public string Ncccode { get; set; }
}
