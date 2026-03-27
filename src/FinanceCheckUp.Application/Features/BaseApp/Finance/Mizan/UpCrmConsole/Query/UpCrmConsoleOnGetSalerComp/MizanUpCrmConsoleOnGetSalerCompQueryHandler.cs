using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpCrmConsole.Query.UpCrmConsoleOnGetSalerComp
{
    public class MizanUpCrmConsoleOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUpCrmConsoleOnGetSalerCompQuery, GenericResult<MizanUpCrmConsoleOnGetSalerCompResponse>>
    {
         
        public Task<GenericResult<MizanUpCrmConsoleOnGetSalerCompResponse>> Handle(MizanUpCrmConsoleOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var mreqListCompany = companyManager.Getby_User(userId); 
                        return Task.FromResult(GenericResult<MizanUpCrmConsoleOnGetSalerCompResponse>.Success(new MizanUpCrmConsoleOnGetSalerCompResponse
            {
                Response = DataSourceLoader.Load(mreqListCompany, request.Request.options)
            }));
        }
    }
}
