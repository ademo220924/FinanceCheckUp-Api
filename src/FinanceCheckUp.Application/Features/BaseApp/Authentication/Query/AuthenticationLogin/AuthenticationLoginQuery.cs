using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Authentication.Query.AuthenticationLogin;

public class AuthenticationLoginQuery : IRequest<GenericResult<LoginResponse>>
{
    public string MailAddress { get; set; }
    public string Password { get; set; }
}