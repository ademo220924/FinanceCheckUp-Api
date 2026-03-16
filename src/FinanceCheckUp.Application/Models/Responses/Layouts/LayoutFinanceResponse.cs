using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Responses.Layouts;

public class LayoutFinanceResponse
{
    public long UserId { get; set; }
    public HhvnUsers HhvnUsers { get; set; }
    public User User { get; set; }
    public string UserRole { get; set; }
    public string UserApp { get; set; }
    public int ChkKonsole { get; set; }
    public bool IsConsole { get; set; }
}