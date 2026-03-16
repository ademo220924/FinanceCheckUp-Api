using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsolList;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGetKonList;
public class CompanyKonsolListOnGetKonListQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<CompanyKonsolListOnGetKonListQuery, GenericResult<CompanyKonsolListOnGetKonListResponse>>
{
    public Task<GenericResult<CompanyKonsolListOnGetKonListResponse>> Handle(CompanyKonsolListOnGetKonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<CompanyKonsolListOnGetKonListResponse>.Success(
            new CompanyKonsolListOnGetKonListResponse
            {
                Response = new JsonResult(DataSourceLoader.Load( companiesManager.UpdateStat_Console(request.Request.ide), request.Request.options))
            }));
    }
}


