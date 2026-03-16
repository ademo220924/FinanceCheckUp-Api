using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.dashbilancomain.Query.dashbilancomainOnGetGraphYear;
public class AktarmaDashbilancomainOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) 
    : IRequestHandler<AktarmaDashbilancomainOnGetGraphYearQuery, GenericResult<AktarmaDashbilancomainOnGetGraphYearResponse>>
{
  
    public Task<GenericResult<AktarmaDashbilancomainOnGetGraphYearResponse>> Handle(AktarmaDashbilancomainOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        hhvnUsersManager.SetYear(request.Request.nyear, userId);
            
        return Task.FromResult(GenericResult<AktarmaDashbilancomainOnGetGraphYearResponse>.Success(
            new AktarmaDashbilancomainOnGetGraphYearResponse
            {
                Response = new JsonResult("OK")
            }));
    }
}