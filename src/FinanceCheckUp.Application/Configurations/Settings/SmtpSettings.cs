namespace FinanceCheckUp.Application.Configurations.Settings;

public class SmtpSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string NetworkCredentialUserName { get; set; }
    public string NetworkCredentialPassword { get; set; }
    public List<string> ToUsers { get; set; }
    public string TargetName { get; set; }
}