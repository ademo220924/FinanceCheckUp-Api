using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpCrmConsole.Query.FinanceUpCrmConsoleOnGetSalerComp;
public class FinanceUpCrmConsoleOnGetSalerCompQueryHandler(ICompanyManager companyManager) 
    : IRequestHandler<FinanceUpCrmConsoleOnGetSalerCompQuery, GenericResult<FinanceUpCrmConsoleOnGetSalerCompResponse>>
{

    public Task<GenericResult<FinanceUpCrmConsoleOnGetSalerCompResponse>> Handle(FinanceUpCrmConsoleOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var mreqListCompany = companyManager.Getby_User(userId);
                return Task.FromResult(GenericResult<FinanceUpCrmConsoleOnGetSalerCompResponse>.Success(new FinanceUpCrmConsoleOnGetSalerCompResponse
        {
            Response = DataSourceLoader.Load(mreqListCompany, request.Request.options)
        }));
    }
}
