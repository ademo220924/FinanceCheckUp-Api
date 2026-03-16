using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGet;
public class MizanCompanyEditOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanCompanyEditOnGetQuery, GenericResult<MizanCompanyEditOnGetResponse>>
{
    public Task<GenericResult<MizanCompanyEditOnGetResponse>> Handle(MizanCompanyEditOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanCompanyEditRequestInitialModel
        {  
            UserID = userId
        };
        
        if (request.Request.id == 0)
        {
            responseModel.mrequest = new Domain.Entities.Company();
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        }
        else
        {
            responseModel.mrequest = companyManager.Get_Company(request.Request.id);
        }
        
        return Task.FromResult(GenericResult<MizanCompanyEditOnGetResponse>.Success(new MizanCompanyEditOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}

