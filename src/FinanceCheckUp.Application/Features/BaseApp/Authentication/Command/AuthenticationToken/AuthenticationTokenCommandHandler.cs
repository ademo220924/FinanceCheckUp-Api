using FinanceCheckUp.Client.QnbClient.Interfaces;
using FinanceCheckUp.Client.QnbClient.Models.Response;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Authentication.Command.AuthenticationToken;

public class AuthenticationTokenCommandHandle(IQnbClient qnbClient) : IRequestHandler<AuthenticationTokenCommand, GenericResult<TokenResponse>>
{
    private readonly IQnbClient _qnbClient = qnbClient ?? throw new ArgumentNullException(nameof(qnbClient));

    public async Task<GenericResult<TokenResponse>> Handle(AuthenticationTokenCommand request, CancellationToken cancellationToken)
    {
        if (request.Settings == null)
            return GenericResult<TokenResponse>.Success(default!);

        var token = await _qnbClient.CreateToken(request.Settings);
        return GenericResult<TokenResponse>.Success(token);
    }
}