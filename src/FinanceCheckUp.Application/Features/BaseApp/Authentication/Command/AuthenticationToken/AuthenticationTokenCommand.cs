using FinanceCheckUp.Client.QnbClient.Models.Request;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Authentication.Command.AuthenticationToken;

public class AuthenticationTokenCommand : IRequest<GenericResult<TokenResponse>>
{
    public Settings? Settings { get; set; }
}