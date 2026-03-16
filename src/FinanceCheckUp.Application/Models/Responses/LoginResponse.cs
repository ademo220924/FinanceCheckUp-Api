using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;

namespace FinanceCheckUp.Application.Models.Responses;

public class LoginResponse : IGenericResponse
{
    public string RedirectUrl { get; set; } = string.Empty;
    public int ResponseDigit { get; set; }

    public string AccessToken { get; set; } = string.Empty;
    public HhvnUsers HhvnUser { get; set; }
    public User User { get; set; }
}