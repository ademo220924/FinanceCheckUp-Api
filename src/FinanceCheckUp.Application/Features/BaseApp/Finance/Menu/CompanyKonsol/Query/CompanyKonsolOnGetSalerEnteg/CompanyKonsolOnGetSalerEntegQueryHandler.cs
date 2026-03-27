using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerEnteg;

public class CompanyKonsolOnGetSalerEntegQueryHandler(ICompanyManager companiesManager) : IRequestHandler<CompanyKonsolOnGetSalerEntegQuery, GenericResult<CompanyKonsolOnGetSalerEntegResponse>>
{
    public Task<GenericResult<CompanyKonsolOnGetSalerEntegResponse>> Handle(CompanyKonsolOnGetSalerEntegQuery request,
        CancellationToken cancellationToken)
    {
        var mreqListCitiy = companiesManager.GetCompany_Entegrator();
                return Task.FromResult(GenericResult<CompanyKonsolOnGetSalerEntegResponse>.Success(
            new CompanyKonsolOnGetSalerEntegResponse
            {
                Response = DataSourceLoader.Load(mreqListCitiy, options: request.Request.options)
            }));
    }
}


