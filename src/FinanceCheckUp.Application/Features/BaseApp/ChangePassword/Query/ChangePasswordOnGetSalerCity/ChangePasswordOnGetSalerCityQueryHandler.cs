using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetSalerCity;
public class ChangePasswordOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<ChangePasswordOnGetSalerCityQuery, GenericResult<ChangePasswordOnGetSalerCityResponse>>
{

    public async Task<GenericResult<ChangePasswordOnGetSalerCityResponse>> Handle(ChangePasswordOnGetSalerCityQuery request, CancellationToken cancellationToken)
    {
        var mreqListCity = citiesManager.Get_Cities();
        return GenericResult<ChangePasswordOnGetSalerCityResponse>.Success(new ChangePasswordOnGetSalerCityResponse { Result = new JsonResult(DataSourceLoader.Load(mreqListCity, options: request.RequestModel.DataSourceLoadOptions)) });
    }
}