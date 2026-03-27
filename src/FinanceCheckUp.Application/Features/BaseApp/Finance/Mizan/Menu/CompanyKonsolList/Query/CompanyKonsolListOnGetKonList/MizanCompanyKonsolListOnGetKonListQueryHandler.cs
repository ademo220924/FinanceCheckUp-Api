using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsolList;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsolList.Query.CompanyKonsolListOnGetKonList;
public class MizanCompanyKonsolListOnGetKonListQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanCompanyKonsolListOnGetKonListQuery, GenericResult<MizanCompanyKonsolListOnGetKonListResponse>>
{
    public Task<GenericResult<MizanCompanyKonsolListOnGetKonListResponse>> Handle(MizanCompanyKonsolListOnGetKonListQuery request, CancellationToken cancellationToken)
    {
        var winModelTlist = companyManager.UpdateStat_Console(request.Request.ide);
                return Task.FromResult(GenericResult<MizanCompanyKonsolListOnGetKonListResponse>.Success(new MizanCompanyKonsolListOnGetKonListResponse
        {
            Response = DataSourceLoader.Load(winModelTlist, request.Request.options)
        }));
    }
}


