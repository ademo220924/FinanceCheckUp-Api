using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutQnbMain;

public class LayoutQnbMainQueryHandler(IHhvnUsersManager hhvnUsersManager): IRequestHandler<LayoutQnbMainQuery, GenericResult<LayoutQnbMainResponse>>
{
    public Task<GenericResult<LayoutQnbMainResponse>> Handle(LayoutQnbMainQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutQnbMainResponse
        { 
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        return Task.FromResult(GenericResult<LayoutQnbMainResponse>.Success(layoutResponse));
    }
}