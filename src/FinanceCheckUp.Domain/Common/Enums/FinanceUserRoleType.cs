
using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;
public enum FinanceUserRoleType
{
    [Description("Admin")] Admin = 1,
    [Description("User")] User,
    [Description("Customer")] Customer,
    [Description("Master")] Master
}