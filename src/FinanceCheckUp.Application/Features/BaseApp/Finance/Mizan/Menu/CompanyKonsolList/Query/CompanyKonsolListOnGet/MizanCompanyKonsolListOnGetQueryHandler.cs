using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsolList;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGet;
public class MizanCompanyKonsolListOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<MizanCompanyKonsolListOnGetQuery, GenericResult<MizanCompanyKonsolListOnGetResponse>>
{

    public Task<GenericResult<MizanCompanyKonsolListOnGetResponse>> Handle(MizanCompanyKonsolListOnGetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanCompanyKonsolListRequestInitialModel
        {  
            UserID = (int)userId,
            mreqList = new List<Domain.Entities.Company>()
        };


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
        responseModel.mrequest = new Domain.Entities.Company();

        if (request.Request.id== 0)
        {
            return Task.FromResult(GenericResult<MizanCompanyKonsolListOnGetResponse>.Success(new MizanCompanyKonsolListOnGetResponse
            {
                InitialModel = responseModel,
                ResponseRedirectUrl="/admin/finance/menu/companylist"
            }));
        }

        responseModel.mrequest = companyManager.Get_Company(request.Request.id);
        responseModel.mreqList = companyManager.Get_ConsoleAll(request.Request.id);

        return Task.FromResult(GenericResult<MizanCompanyKonsolListOnGetResponse>.Success(new MizanCompanyKonsolListOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}



