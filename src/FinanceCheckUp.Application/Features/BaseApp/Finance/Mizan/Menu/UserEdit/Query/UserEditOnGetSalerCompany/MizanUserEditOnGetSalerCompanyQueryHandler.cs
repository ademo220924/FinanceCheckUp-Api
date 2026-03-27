using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetSalerCompany;


public class MizanUserEditOnGetSalerCompanyQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanUserEditOnGetSalerCompanyQuery, GenericResult<MizanUserEditOnGetSalerCompanyResponse>>
{
    public Task<GenericResult<MizanUserEditOnGetSalerCompanyResponse>> Handle(MizanUserEditOnGetSalerCompanyQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;

        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
        request.InitialModel.mreqListCompany = new List<Domain.Entities.Company>();

        if ( request.InitialModel.CurrentUser.UserTypeID == 1001)
        {
            request.InitialModel.mreqListCompany = companyManager.Get_All();
        }
        else if ( request.InitialModel.CurrentUser.UserTypeID == 4)
        {
            request.InitialModel.mreqListCompany = companyManager.Getby_User( request.InitialModel.UserID);
        } 
                return Task.FromResult(GenericResult<MizanUserEditOnGetSalerCompanyResponse>.Success(new MizanUserEditOnGetSalerCompanyResponse
        {
            InitialModel = request.InitialModel,
            Response= DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)
        }));
    }
}