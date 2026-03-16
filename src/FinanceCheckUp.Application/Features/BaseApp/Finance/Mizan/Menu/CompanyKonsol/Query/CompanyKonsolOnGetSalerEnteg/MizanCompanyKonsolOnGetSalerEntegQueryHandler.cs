using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.CompanyKonsol.Query.CompanyKonsolOnGetSalerEnteg;

public class MizanCompanyKonsolOnGetSalerEntegQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanCompanyKonsolOnGetSalerEntegQuery, GenericResult<MizanCompanyKonsolOnGetSalerEntegResponse>>
{
    public Task<GenericResult<MizanCompanyKonsolOnGetSalerEntegResponse>> Handle(MizanCompanyKonsolOnGetSalerEntegQuery request, CancellationToken cancellationToken)
    {
       var mreqListCitiy = companyManager.GetCompany_Entegrator();
       return Task.FromResult(GenericResult<MizanCompanyKonsolOnGetSalerEntegResponse>.Success(new MizanCompanyKonsolOnGetSalerEntegResponse
       {
           Response =new JsonResult(DataSourceLoader.Load(mreqListCitiy, request.Request.options))
       }));
    }
}


