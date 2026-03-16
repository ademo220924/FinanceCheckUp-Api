using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutConsult;

public class LayoutConsultQueryHandler(IHhvnUsersManager hhvnUsersManager): IRequestHandler<LayoutConsultQuery, GenericResult<LayoutConsultResponse>>
{
    public Task<GenericResult<LayoutConsultResponse>> Handle(LayoutConsultQuery request, CancellationToken cancellationToken)
    {
        var layoutResponse = new LayoutConsultResponse
        {  
            UserId = Convert.ToInt64(request.UserId)
        };

        layoutResponse.HhvnUsers= hhvnUsersManager.GetRow_User(layoutResponse.UserId);
        layoutResponse.UserApp = "";
        layoutResponse.UserRole = "Admin"; //ToDo: httpcontextten al
        return Task.FromResult(GenericResult<LayoutConsultResponse>.Success(layoutResponse));
    }
}