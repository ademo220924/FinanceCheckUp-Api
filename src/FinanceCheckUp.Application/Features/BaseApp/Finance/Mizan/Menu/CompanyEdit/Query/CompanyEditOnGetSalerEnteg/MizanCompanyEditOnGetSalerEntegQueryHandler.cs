using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGet;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyEdit.Query.CompanyEditOnGetSalerEnteg;
public class MizanCompanyEditOnGetSalerEntegQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanCompanyEditOnGetSalerEntegQuery, GenericResult<MizanCompanyEditOnGetSalerEntegResponse>>
{
    public Task<GenericResult<MizanCompanyEditOnGetSalerEntegResponse>> Handle(MizanCompanyEditOnGetSalerEntegQuery request, CancellationToken cancellationToken)
    {
        var mreqListCitiy = companyManager.GetCompany_Entegrator();
                return Task.FromResult(GenericResult<MizanCompanyEditOnGetSalerEntegResponse>.Success(new MizanCompanyEditOnGetSalerEntegResponse
        {
            Response = DataSourceLoader.Load(mreqListCitiy, request.Request.options)
        }));
    }
}

