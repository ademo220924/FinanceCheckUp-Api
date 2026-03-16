using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashBilancoKon;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGetGraphYear;
public class MizanDashBilancoKonOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager) 
    : IRequestHandler<MizanDashBilancoKonOnGetGraphYearQuery, GenericResult<MizanDashBilancoKonOnGetGraphYearResponse>>
{
    public Task<GenericResult<MizanDashBilancoKonOnGetGraphYearResponse>> Handle(MizanDashBilancoKonOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashBilancoKonRequestInitialModel
        {
            UserID = userId
        }; 
        
        hhvnUsersManager.SetYear(request.Request.nyear, responseModel.UserID);
       
        return Task.FromResult(GenericResult<MizanDashBilancoKonOnGetGraphYearResponse>.Success(
                new MizanDashBilancoKonOnGetGraphYearResponse
                {
                    InitialModel = responseModel,
                    Response =  new JsonResult("ok")
                }));
    }
}
