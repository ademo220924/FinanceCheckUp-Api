using FinanceCheckUp.Application.Models.SignOperation;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Services.Interfaces;

public interface IAuthenticationHelperService
{
    AccessToken SignIn(User user, CancellationToken cancellationToken);
    string GetBaseUrl();
}