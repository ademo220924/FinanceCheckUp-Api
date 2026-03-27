using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerCity;

public class MizanCompanyKonsolOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<MizanCompanyKonsolOnGetSalerCityQuery, GenericResult<MizanCompanyKonsolOnGetSalerCityResponse>>
{
    public Task<GenericResult<MizanCompanyKonsolOnGetSalerCityResponse>> Handle(MizanCompanyKonsolOnGetSalerCityQuery request, CancellationToken cancellationToken)
    {
       var mreqListCitiy = citiesManager.Get_Cities();
              return Task.FromResult(GenericResult<MizanCompanyKonsolOnGetSalerCityResponse>.Success(new MizanCompanyKonsolOnGetSalerCityResponse
       {
           Response = DataSourceLoader.Load(mreqListCitiy, request.Request.options)
       }));
    }
}
