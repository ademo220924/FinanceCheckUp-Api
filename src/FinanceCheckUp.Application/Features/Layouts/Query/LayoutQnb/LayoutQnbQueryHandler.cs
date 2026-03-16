using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutQnb;

public class LayoutQnbQueryHandler(IHhvnUsersManager hhvnUsersManager): IRequestHandler<LayoutQnbQuery, GenericResult<LayoutQnbResponse>>
{
    public Task<GenericResult<LayoutQnbResponse>> Handle(LayoutQnbQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutQnbResponse
        { 
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        return Task.FromResult(GenericResult<LayoutQnbResponse>.Success(layoutResponse));
    }
}