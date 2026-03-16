namespace FinanceCheckUp.Application.Models.Requests;

public class LoginRequest
{
    public string MailAddress { get; set; }
    public string Password { get; set; }
}