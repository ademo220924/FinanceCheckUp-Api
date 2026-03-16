using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerCity;

public class CompanyKonsolOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<CompanyKonsolOnGetSalerCityQuery, GenericResult<CompanyKonsolOnGetSalerCityResponse>>
{
    public Task<GenericResult<CompanyKonsolOnGetSalerCityResponse>> Handle(CompanyKonsolOnGetSalerCityQuery request,
        CancellationToken cancellationToken)
    {
        var mreqListCitiy = citiesManager.Get_Cities();
        return Task.FromResult(GenericResult<CompanyKonsolOnGetSalerCityResponse>.Success(
            new CompanyKonsolOnGetSalerCityResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(mreqListCitiy, request.Request.options))
            }));
    }
}
