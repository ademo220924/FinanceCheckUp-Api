namespace FinanceCheckUp.Domain.Dtos.BgServer.RuleJobHistories;

public class RuleJobHistoryResponseDto
{
    public string? Company { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public string? AccountName { get; set; }
    public string? AccountGroupName { get; set; }
    public long ReminderRuleJobId { get; set; }
    public double ControlValue { get; set; }
    public double CalculateValue { get; set; }
    public double DifferentValue { get; set; }
    public double DifferentPercentage { get; set; }
    public string? Explanation { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? ControlValueType { get; set; }
    public string? PeriodType { get; set; }
}