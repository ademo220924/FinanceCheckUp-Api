using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.ChangePassword;
using FinanceCheckUp.Application.Models.Responses.ChangePassword;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.ChangePassword.Query.ChangePasswordOnGet;
public class ChangePasswordOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserTypeManager userTypeManager, ICompanyManager companyManager) : IRequestHandler<ChangePasswordOnGetQuery, GenericResult<ChangePasswordOnGetResponse>>
{

    public ChangePasswordRequest responseModel = new();

    public async Task<GenericResult<ChangePasswordOnGetResponse>> Handle(ChangePasswordOnGetQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt64(request.UserId);

        responseModel.myearResult = YearResult.getValue();
        responseModel.UserID = UserID;
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mrequest = hhvnUsersManager.GetRow_User(UserID);
        responseModel.mrequest.Password = CryptoOperationExtension.Decrypt(responseModel.mrequest.Password);
        responseModel.mreqListUserType = userTypeManager.Get_Types();

        var mreqListCompany = new List<Domain.Entities.Company>();

        mreqListCompany = companyManager.Getby_User(UserID).ToList();
        responseModel.mrequest.CompanyList = mreqListCompany.Select(x => x.Id).ToList();

        var mreqListCitystr = string.Join(";", responseModel.mrequest.CompanyList);

        return GenericResult<ChangePasswordOnGetResponse>.Success(new ChangePasswordOnGetResponse { InitialModel = responseModel });
    }
}
