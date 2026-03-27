using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetSalerComp;
public class FinanceUpPageAktarmaJrnlOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetSalerCompQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerCompResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerCompResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
        
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerCompResponse>.Success(new FinanceUpPageAktarmaJrnlOnGetSalerCompResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)
        }));
    }
}
