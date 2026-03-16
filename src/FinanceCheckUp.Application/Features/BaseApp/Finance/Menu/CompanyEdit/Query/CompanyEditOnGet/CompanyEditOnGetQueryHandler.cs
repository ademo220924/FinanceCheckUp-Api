using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGet;

public class CompanyEditOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager)
    : IRequestHandler<CompanyEditOnGetQuery, GenericResult<CompanyEditOnGetResponse>>
{
    public Task<GenericResult<CompanyEditOnGetResponse>> Handle(CompanyEditOnGetQuery request, CancellationToken cancellationToken)
    {

        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new CompanyEditInitialModel { UserID = userId };
        if (request.Id == 0)
        {
            responseModel.mrequest = new Domain.Entities.Company();

            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        }
        else
        {
            responseModel.mrequest = companyManager.Get_Company(request.Id);
        }
        
        return Task.FromResult(GenericResult<CompanyEditOnGetResponse>.Success(new CompanyEditOnGetResponse { InitialModel = responseModel }));
    }
}

