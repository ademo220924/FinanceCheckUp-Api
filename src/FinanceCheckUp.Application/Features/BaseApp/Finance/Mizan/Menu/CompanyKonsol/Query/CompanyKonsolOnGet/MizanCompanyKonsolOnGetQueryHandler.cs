using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsol.Query.CompanyKonsolOnGet;

public class MizanCompanyKonsolOnGetQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanCompanyKonsolOnGetQuery, GenericResult<MizanCompanyKonsolOnGetResponse>>
{
    
    public Task<GenericResult<MizanCompanyKonsolOnGetResponse>> Handle(MizanCompanyKonsolOnGetQuery request, CancellationToken cancellationToken)
    {
        var responseModel = new MizanCompanyKonsolRequestInitialModel
        {
            mrequest = new Domain.Entities.Company(),
            mrequestmain = companyManager.Get_Company(request.Request.mainid)
        };

        responseModel.mrequest.MainCompanyId = request.Request.mainid;
        if (request.Request.id != 0)
        {
            responseModel.mrequest = companyManager.Get_Company(request.Request.id);
        }
        
        
        return Task.FromResult(GenericResult<MizanCompanyKonsolOnGetResponse>.Success(new MizanCompanyKonsolOnGetResponse
        {
            InitialModel = responseModel
        }));
    }
}