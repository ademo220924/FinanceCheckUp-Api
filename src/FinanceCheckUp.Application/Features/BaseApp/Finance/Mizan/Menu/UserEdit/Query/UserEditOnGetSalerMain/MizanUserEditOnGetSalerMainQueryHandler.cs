using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetSalerMain;
public class MizanUserEditOnGetSalerMainQueryHandler(IHhvnUsersManager hhvnUsersManager,  IUserTypeManager userTypeManager) : IRequestHandler<MizanUserEditOnGetSalerMainQuery, GenericResult<MizanUserEditOnGetSalerMainResponse>>
{
    public Task<GenericResult<MizanUserEditOnGetSalerMainResponse>> Handle(MizanUserEditOnGetSalerMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;

        
        request.InitialModel.mreqListUserType = userTypeManager.Get_Types();

        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.mreqListCompany = new List<Domain.Entities.Company>();

        request.InitialModel.mreqListUserType = request.InitialModel.CurrentUser.UserTypeID switch
        {
            1001 => userTypeManager.Get_Types(),
            4 => userTypeManager.Get_Types().Where(x => x.Id != 1001).ToList(),
            _ => userTypeManager.Get_Types().Where(x => x.Id != 1001 && x.Id != 4).ToList()
        };

        return Task.FromResult(GenericResult<MizanUserEditOnGetSalerMainResponse>.Success(new MizanUserEditOnGetSalerMainResponse
        {
            InitialModel = request.InitialModel,
            Response= new JsonResult(DataSourceLoader.Load(request.InitialModel.mreqListUserType, request.Request.options))
        }));
    }
}
