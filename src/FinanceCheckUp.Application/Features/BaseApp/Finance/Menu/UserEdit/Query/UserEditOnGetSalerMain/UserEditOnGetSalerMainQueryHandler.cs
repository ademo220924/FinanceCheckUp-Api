using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.UserEdit.Query.UserEditOnGetSalerMain;
public class UserEditOnGetSalerMainQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<UserEditOnGetSalerMainQuery, GenericResult<UserEditOnGetSalerMainResponse>>
{
    public Task<GenericResult<UserEditOnGetSalerMainResponse>> Handle(UserEditOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = request.InitialModel;
        responseModel.UserID = userId;
        
        responseModel.mreqListUserType = userTypeManager.Get_Types();

        
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mreqListCompany = new List<Domain.Entities.Company>();

        if (responseModel.CurrentUser.UserTypeID == 1001)
        {
            responseModel.mreqListUserType = userTypeManager.Get_Types();
        }
        else if (responseModel.CurrentUser.UserTypeID == 4)
        {
            responseModel.mreqListUserType = userTypeManager.Get_Types().Where(x => x.Id != 1001).ToList();
        }
        else
        {
            responseModel.mreqListUserType = userTypeManager.Get_Types().Where(x => x.Id != 1001 && x.Id != 4).ToList();
        }
 
        return Task.FromResult(GenericResult<UserEditOnGetSalerMainResponse>.Success(
            new UserEditOnGetSalerMainResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(responseModel.mreqListUserType, request.Request.options)),
                InitialModel=request.InitialModel
            }));
    }
}
