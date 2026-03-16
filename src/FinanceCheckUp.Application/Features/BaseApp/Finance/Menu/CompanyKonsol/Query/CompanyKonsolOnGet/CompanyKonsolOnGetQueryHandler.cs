using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGet;

public class CompanyKonsolOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<CompanyKonsolOnGetQuery, GenericResult<CompanyKonsolOnGetResponse>>
{
    public Task<GenericResult<CompanyKonsolOnGetResponse>> Handle(CompanyKonsolOnGetQuery request, CancellationToken cancellationToken)
    {
        var responseModel = new CompanyKonsolInitialModel
        {
            mrequest = new Domain.Entities.Company(),
            mrequestmain = companiesManager.Get_Company(request.MainID)
        };

        responseModel.mrequest.MainCompanyId = request.MainID;
        if (request.Id != 0)
        {
            responseModel.mrequest = companiesManager.Get_Company(request.Id);

        }
        
        return Task.FromResult(GenericResult<CompanyKonsolOnGetResponse>.Success(new CompanyKonsolOnGetResponse { InitialModel = responseModel }));
    }
}