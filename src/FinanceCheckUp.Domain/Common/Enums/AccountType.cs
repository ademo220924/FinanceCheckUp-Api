using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;

public enum AccountType
{
    [Description("Revenue Main Account Id")] RevenueMainAccount = 1,
    [Description("Revenue Type Id")] RevenueType = 2,
    [Description("Balance Main Account Id")] BalanceMainAccount = 3,
    [Description("Balance Type Id")] BalanceType = 4
}