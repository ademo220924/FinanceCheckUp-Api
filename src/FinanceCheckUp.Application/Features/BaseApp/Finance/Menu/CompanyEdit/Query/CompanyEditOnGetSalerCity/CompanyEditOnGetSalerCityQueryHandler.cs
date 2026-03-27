using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyEdit.Query.CompanyEditOnGetSalerCity;
public class CompanyEditOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<CompanyEditOnGetSalerCityQuery, GenericResult<CompanyEditOnGetSalerCityResponse>>
{
    public Task<GenericResult<CompanyEditOnGetSalerCityResponse>> Handle(CompanyEditOnGetSalerCityQuery request, CancellationToken cancellationToken)
    {
                return Task.FromResult(GenericResult<CompanyEditOnGetSalerCityResponse>.Success(
            new CompanyEditOnGetSalerCityResponse
            {
                Response = DataSourceLoader.Load(citiesManager.Get_Cities(), request.Request.options)
            }));
    }
}

