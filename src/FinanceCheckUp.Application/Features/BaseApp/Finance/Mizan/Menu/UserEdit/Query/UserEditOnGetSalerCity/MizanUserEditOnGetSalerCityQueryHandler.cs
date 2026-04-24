using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using DevExtreme.AspNet.Data;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetSalerCity;

public class MizanUserEditOnGetSalerCityQueryHandler(ICitiesManager citiesManager) : IRequestHandler<MizanUserEditOnGetSalerCityQuery, GenericResult<MizanUserEditOnGetSalerCityResponse>>
{
    public Task<GenericResult<MizanUserEditOnGetSalerCityResponse>> Handle(MizanUserEditOnGetSalerCityQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenericResult<MizanUserEditOnGetSalerCityResponse>.Success(new MizanUserEditOnGetSalerCityResponse
        {
            Response = DataSourceLoader.Load(citiesManager.Get_Cities(), request.Request.options)
        }));

    }
}

