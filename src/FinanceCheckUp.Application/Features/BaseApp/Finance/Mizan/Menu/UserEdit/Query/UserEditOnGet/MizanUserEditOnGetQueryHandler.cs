using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Application.Common.Utilities;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGet;

public class MizanUserEditOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, IUserTypeManager userTypeManager, ICompanyManager companyManager) 
    : IRequestHandler<MizanUserEditOnGetQuery, GenericResult<MizanUserEditOnGetResponse>>
{
    

    public Task<GenericResult<MizanUserEditOnGetResponse>> Handle(MizanUserEditOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanUserEditRequestInitialModel
        {  
            UserID = userId,
            myearResult = YearResult.getValue()
        };


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        if (request.Request.id == 0)
        {
            responseModel.mrequest = new HhvnUsers();
        }
        else
        {
            responseModel.mrequest = hhvnUsersManager.GetRow_User(request.Request.id);
            responseModel.mrequest.Password = HashingHelper.Decrypt(responseModel.mrequest.Password);
        }
        responseModel.mreqListUserType = userTypeManager.Get_Types();


        responseModel.mreqListCompany = new List<Domain.Entities.Company>();

        responseModel.mreqListCompany = companyManager.Getby_User(request.Request.id);
        responseModel.mrequest.CompanyList = responseModel.mreqListCompany.Select(x => x.Id).ToList();

        responseModel.mreqListCitiystr = string.Join(";", responseModel.mrequest.CompanyList);
        
        
        return Task.FromResult(GenericResult<MizanUserEditOnGetResponse>.Success(new MizanUserEditOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}


