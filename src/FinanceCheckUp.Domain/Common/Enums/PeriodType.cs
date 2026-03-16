using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;

public enum PeriodType
{
    [Description("Monthly")] Monthly = 1,
    [Description("Quarterly")] Quarterly = 2,
    [Description("Yearly")] Yearly = 3
}