namespace FinanceCheckUp.Application.Common.Constants;

public static class SqlQueryConst
{
    public static string GetPasswordwithAppUser = "SELECT * FROM   [dbo].[User] WHERE Email={0}";
}