using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetGraphComp;
public class UploadOnGetGraphCompQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserCompanyManager userCompanyManager) : IRequestHandler<UploadOnGetGraphCompQuery, GenericResult<UploadOnGetGraphCompResponse>>
{

    public async Task<GenericResult<UploadOnGetGraphCompResponse>> Handle(UploadOnGetGraphCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        if (request.Request.ncompid < 1)
            return GenericResult<UploadOnGetGraphCompResponse>.Success(new UploadOnGetGraphCompResponse { Result = new JsonResult("nok") });

        if (hhvnUsersManager.CheckUser(request.Request.ncompid, UserID))
            userCompanyManager.Update_UserDefault(UserID, request.Request.ncompid);

        return GenericResult<UploadOnGetGraphCompResponse>.Success(new UploadOnGetGraphCompResponse { Result = new JsonResult("ok") });
    }
}