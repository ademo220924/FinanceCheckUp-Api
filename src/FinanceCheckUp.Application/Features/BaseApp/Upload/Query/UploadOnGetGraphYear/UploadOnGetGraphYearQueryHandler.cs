using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetGraphYear;
public class UploadOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) : IRequestHandler<UploadOnGetGraphYearQuery, GenericResult<UploadOnGetGraphYearResponse>>
{

    public async Task<GenericResult<UploadOnGetGraphYearResponse>> Handle(UploadOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, UserID);
        return GenericResult<UploadOnGetGraphYearResponse>.Success(new UploadOnGetGraphYearResponse { Result = new JsonResult("ok") });
    }
}