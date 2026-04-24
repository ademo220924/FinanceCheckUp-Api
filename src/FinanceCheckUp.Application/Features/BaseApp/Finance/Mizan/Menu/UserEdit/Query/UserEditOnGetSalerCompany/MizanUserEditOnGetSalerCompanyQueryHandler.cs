using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetSalerCompany;

public class MizanUserEditOnGetSalerCompanyQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanUserEditOnGetSalerCompanyQuery, GenericResult<MizanUserEditOnGetSalerCompanyResponse>>
{
    public Task<GenericResult<MizanUserEditOnGetSalerCompanyResponse>> Handle(MizanUserEditOnGetSalerCompanyQuery request, CancellationToken cancellationToken)
    {
        var sessionUserId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanUserEditRequestInitialModel
        {
            UserID = sessionUserId,
            CurrentUser = hhvnUsersManager.GetRow_User(sessionUserId),
            mreqListCompany = new List<Domain.Entities.Company>()
        };

        if (request.Request != null && request.Request.EditedUserId > 0)
        {
            responseModel.mreqListCompany = companyManager.Getby_User(request.Request.EditedUserId).ToList();
        }
        else if (responseModel.CurrentUser.UserTypeID == 1001)
        {
            responseModel.mreqListCompany = companyManager.Get_All().ToList();
        }
        else if (responseModel.CurrentUser.UserTypeID == 4)
        {
            responseModel.mreqListCompany = companyManager.Getby_User(sessionUserId).ToList();
        }

        return Task.FromResult(GenericResult<MizanUserEditOnGetSalerCompanyResponse>.Success(new MizanUserEditOnGetSalerCompanyResponse
        {
            InitialModel = responseModel,
            Response = DataSourceLoader.Load(responseModel.mreqListCompany, request.Request.options)
        }));
    }
}