using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetSalerCompany;


public class UserEditOnGetSalerCompanyQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<UserEditOnGetSalerCompanyQuery, GenericResult<UserEditOnGetSalerCompanyResponse>>
{

    public Task<GenericResult<UserEditOnGetSalerCompanyResponse>> Handle(UserEditOnGetSalerCompanyQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = request.UserEditInitialModel;
        responseModel.UserID = userId;
        responseModel.myearResult = YearResult.getValue();
         
        
         
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = new List<Domain.Entities.Company>();
        
        if (responseModel.CurrentUser.UserTypeID == 1001)
        {
            responseModel.mreqListCompany = companyManager.Get_All();
        }
        else if (responseModel.CurrentUser.UserTypeID == 4)
        {
            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
        }
     
                return Task.FromResult(GenericResult<UserEditOnGetSalerCompanyResponse>.Success(
            new UserEditOnGetSalerCompanyResponse
            {
                Response = DataSourceLoader.Load(responseModel.mreqListCompany, request.Request.options),
                InitialModel= request.UserEditInitialModel
            }));
    }
}