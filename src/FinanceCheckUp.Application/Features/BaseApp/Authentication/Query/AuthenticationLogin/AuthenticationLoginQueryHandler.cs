using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Application.Features.BaseApp.Authentication.Query.AuthenticationLogin;

public class AuthenticationLoginQueryHandle(
    IUserLoginManager _userLoginManager,
    IHttpContextAccessor _httpContextAccessor,
    IUserManager userManager,
    IAuthenticationHelperService authenticationHelperService,
    IHhvnUsersManager hhvnUsersManager
    ) : IRequestHandler<AuthenticationLoginQuery, GenericResult<LoginResponse>>
{

    public Task<GenericResult<LoginResponse>> Handle(AuthenticationLoginQuery request, CancellationToken cancellationToken)
    {

        var appUser = userManager.GetPasswordwithAppUser(request.MailAddress);

        if (appUser is not { Id: > 0 })
            throw new UserNotFoundException(nameof(User), request.MailAddress);

        if (!appUser.IsActive)
            throw new UserInfoException("Hesabınız aktif değil");

        var passwordEncrypt = CryptoOperationExtension.Encrypt(request.Password);
        if (passwordEncrypt != appUser.Password)
            throw new UserInfoException("Kullanıcı adı veya şifre hatalı");

        _userLoginManager.Save_User(new UserLogin
        {
            UserBrowser = _httpContextAccessor.HttpContext!.Request.Headers.UserAgent!,
            UserIp = _httpContextAccessor.HttpContext!.Connection.RemoteIpAddress!.ToString(),
            UserId = (int)appUser.Id
        });


        var hhvnUser = hhvnUsersManager.GetPasswordwithAppUser(request.MailAddress);
        var token = authenticationHelperService.SignIn(appUser, cancellationToken);

        return Task.FromResult(GenericResult<LoginResponse>.Success(string.IsNullOrEmpty(appUser.QnbUserId)
            ? new LoginResponse { RedirectUrl = "/Admin/finance/mizan/menu/firmpanel", ResponseDigit = 1, AccessToken = token.Token,HhvnUser = hhvnUser,User = appUser}
            : new LoginResponse { RedirectUrl = "/Admin/qnb/index", ResponseDigit = 3, AccessToken = token.Token,HhvnUser = hhvnUser ,User = appUser}));
    }



}