using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGetSalerCity;
public class MizanCompanyEditOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<MizanCompanyEditOnGetSalerCityQuery, GenericResult<MizanCompanyEditOnGetSalerCityResponse>>
{
   
    public Task<GenericResult<MizanCompanyEditOnGetSalerCityResponse>> Handle(MizanCompanyEditOnGetSalerCityQuery request, CancellationToken cancellationToken)
    {
        var mreqListCitiy = citiesManager.Get_Cities();
        return Task.FromResult(GenericResult<MizanCompanyEditOnGetSalerCityResponse>.Success(new MizanCompanyEditOnGetSalerCityResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(mreqListCitiy, request.Request.options))
        }));
    }
}

