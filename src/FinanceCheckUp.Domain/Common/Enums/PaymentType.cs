using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;

public enum PaymentType
{
    [Description("Debit")]
    Debit = 1,
    [Description("Credit")]
    Credit = 2,
}