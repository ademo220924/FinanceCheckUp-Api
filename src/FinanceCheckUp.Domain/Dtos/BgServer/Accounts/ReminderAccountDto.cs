using FinanceCheckUp.Domain.Common.Enums;

namespace FinanceCheckUp.Domain.Dtos.BgServer.Accounts;

public class ReminderAccountDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int StartValue { get; set; }
    public int FinishValue { get; set; }
    public int AccountGroupId { get; set; }
    public string? AccountGroupName { get; set; }
    public AccountType AccountType { get; set; }
    public string? AccountTypeText { get; set; }
}