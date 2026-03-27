using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerComp;
public class FinanceUpPageAktarmaOnGetSalerCompQueryHandler(ICompanyManager companyManager) 
    : IRequestHandler<FinanceUpPageAktarmaOnGetSalerCompQuery, GenericResult<FinanceUpPageAktarmaOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaOnGetSalerCompResponse>> Handle(FinanceUpPageAktarmaOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
         
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetSalerCompResponse>.Success(new FinanceUpPageAktarmaOnGetSalerCompResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)
        }));
    }
}
