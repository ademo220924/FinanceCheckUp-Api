using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsolList;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsolList;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGet;
public class CompanyKonsolListOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager) : IRequestHandler<CompanyKonsolListOnGetQuery, GenericResult<CompanyKonsolListOnGetResponse>>
{
   

    public   Task<GenericResult<CompanyKonsolListOnGetResponse>> Handle(CompanyKonsolListOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new CompanyKonsolListInitialModel
        {
            UserID = (int)userId,
            mreqList = new List<Domain.Entities.Company>(),
            CurrentUser = hhvnUsersManager.GetRow_User(userId),
            mrequest = new Domain.Entities.Company()
        };

        if (request.Request.id== 0)
        { 
            return Task.FromResult(GenericResult<CompanyKonsolListOnGetResponse>.Success(
                new CompanyKonsolListOnGetResponse
                {
                    InitialModel = responseModel,
                    RedirectUrl = "/admin/finance/menu/companylist"
                }));
        }
        else
        {
            responseModel.mrequest = companiesManager.Get_Company(request.Request.id);
            responseModel.mreqList = companiesManager.Get_ConsoleAll(request.Request.id);
            
            
            return Task.FromResult(GenericResult<CompanyKonsolListOnGetResponse>.Success(
                new CompanyKonsolListOnGetResponse
                {
                    InitialModel = responseModel,
                    RedirectUrl = string.Empty
                }));
        }
    }
}