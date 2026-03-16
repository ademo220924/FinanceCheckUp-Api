using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;

public enum ControlValueType
{
    [Description("Artmıştır")] Increment = 1,
    [Description("Azalmıştır")] Decrease = 2
}