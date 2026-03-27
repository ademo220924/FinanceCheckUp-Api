using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetSalerCompany;
public class ChangePasswordOnGetSalerCompanyQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<ChangePasswordOnGetSalerCompanyQuery, GenericResult<ChangePasswordOnGetSalerCompanyResponse>>
{

    public async Task<GenericResult<ChangePasswordOnGetSalerCompanyResponse>> Handle(ChangePasswordOnGetSalerCompanyQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt64(request.UserId);

        var CurrentUser = hhvnUsersManager.GetRow_User(UserID);

        switch (CurrentUser.UserTypeID)
        {
            case 1001:
                request.RequestModel.InitialModel.mreqListCompany = companyManager.Get_All();
                break;
            case 4:
                request.RequestModel.InitialModel.mreqListCompany = companyManager.Getby_User(UserID);
                break;
        }

                return GenericResult<ChangePasswordOnGetSalerCompanyResponse>.Success(new ChangePasswordOnGetSalerCompanyResponse { Result = DataSourceLoader.Load(request.RequestModel.InitialModel.mreqListCompany, options: request.RequestModel.DataSourceLoadOptions) });
    }
}