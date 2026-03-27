using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGetSalerEnteg;
public class CompanyEditOnGetSalerEntegQueryHandler(ICompanyManager companiesManager) : IRequestHandler<CompanyEditOnGetSalerEntegQuery, GenericResult<CompanyEditOnGetSalerEntegResponse>>
{
    public Task<GenericResult<CompanyEditOnGetSalerEntegResponse>> Handle(CompanyEditOnGetSalerEntegQuery request, CancellationToken cancellationToken)
    {
                return Task.FromResult(GenericResult<CompanyEditOnGetSalerEntegResponse>.Success(
            new CompanyEditOnGetSalerEntegResponse
            {
                Response = DataSourceLoader.Load(companiesManager.GetCompany_Entegrator(), request.Request.options)
            }));
    }
}

