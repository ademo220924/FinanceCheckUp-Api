using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGetSalerMain;
public class ChangePasswordOnGetSalerMainQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IUserTypeManager userTypeManager) : IRequestHandler<ChangePasswordOnGetSalerMainQuery, GenericResult<ChangePasswordOnGetSalerMainResponse>>
{
    public async Task<GenericResult<ChangePasswordOnGetSalerMainResponse>> Handle(ChangePasswordOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);
        var CurrentUser = hhvnUsersManager.GetRow_User(UserID);

        var mreqListUserType = CurrentUser.UserTypeID switch
        {
            1001 => userTypeManager.Get_Types(),
            4 => userTypeManager.Get_Types().Where(x => x.Id != 1001).ToList(),
            _ => userTypeManager.Get_Types().Where(x => x.Id != 1001 && x.Id != 4).ToList(),
        };
                return GenericResult<ChangePasswordOnGetSalerMainResponse>.Success(new ChangePasswordOnGetSalerMainResponse { Result = DataSourceLoader.Load(request.RequestModel.InitialModel.mreqListCompany, options: request.RequestModel.DataSourceLoadOptions) });
    }
}