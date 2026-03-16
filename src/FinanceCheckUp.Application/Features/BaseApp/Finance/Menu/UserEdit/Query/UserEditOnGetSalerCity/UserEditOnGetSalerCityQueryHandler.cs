using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using DevExtreme.AspNet.Data;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetSalerCity;

public class UserEditOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<UserEditOnGetSalerCityQuery, GenericResult<UserEditOnGetSalerCityResponse>>
{

    public Task<GenericResult<UserEditOnGetSalerCityResponse>> Handle(UserEditOnGetSalerCityQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<UserEditOnGetSalerCityResponse>.Success(
            new UserEditOnGetSalerCityResponse
            {
                Response = new JsonResult(DataSourceLoader.Load( citiesManager.Get_Cities(), request.Request.options))
            }));
    }
}

