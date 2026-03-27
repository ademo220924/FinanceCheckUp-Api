using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGetSalerComp;
public class FinanceUpPageAktarmaMznOnGetSalerCompQueryHandler(ICompanyManager companyManager) 
    : IRequestHandler<FinanceUpPageAktarmaMznOnGetSalerCompQuery, GenericResult<FinanceUpPageAktarmaMznOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaMznOnGetSalerCompResponse>> Handle(FinanceUpPageAktarmaMznOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
        
                  return Task.FromResult(GenericResult<FinanceUpPageAktarmaMznOnGetSalerCompResponse>.Success(new FinanceUpPageAktarmaMznOnGetSalerCompResponse
                {
                    InitialModel = request.InitialModel,
                    Response = DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)
                }));
    }
}
