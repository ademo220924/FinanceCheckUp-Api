using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.CashFlow.Query.CashFlowOnGetGraphYear;
public class MizanCashFlowOnGetGraphYearQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanCashFlowOnGetGraphYearQuery, GenericResult<MizanCashFlowOnGetGraphYearResponse>>
{
    
    public Task<GenericResult<MizanCashFlowOnGetGraphYearResponse>> Handle(MizanCashFlowOnGetGraphYearQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanCashFlowRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
        
        
         hhvnUsersManager.SetYear(request.Request.nyear, responseModel.UserID);
         return Task.FromResult(GenericResult<MizanCashFlowOnGetGraphYearResponse>.Success(new MizanCashFlowOnGetGraphYearResponse() { Response = new JsonResult("ok") }));
    }
}
