using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGetGraphYear;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Konsol.DashRevenueKon.Query.DashRevenueKonOnGetGraphYear;
public class MizanDashRevenueKonOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashRevenueKonOnGetGraphYearQuery, GenericResult<MizanDashRevenueKonOnGetGraphYearResponse>>
{
    public Task<GenericResult<MizanDashRevenueKonOnGetGraphYearResponse>> Handle(MizanDashRevenueKonOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRevenueKonRequestInitialModel
        {
            UserID = userId
        }; 
        hhvnUsersManager.SetYear(request.Request.nyear, responseModel.UserID);
        
        return Task.FromResult(GenericResult<MizanDashRevenueKonOnGetGraphYearResponse>.Success(
                new MizanDashRevenueKonOnGetGraphYearResponse
                {
                    InitialModel = responseModel,
                    Response =  new JsonResult("ok")
                }));
    }
}

