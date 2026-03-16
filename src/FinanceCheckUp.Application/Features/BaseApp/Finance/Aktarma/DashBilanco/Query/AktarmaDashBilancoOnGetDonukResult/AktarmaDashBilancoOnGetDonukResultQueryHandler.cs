using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetDonukResult;
public class AktarmaDashBilancoOnGetDonukResultQueryHandler(ICompanyManager companiesManager) 
    : IRequestHandler<AktarmaDashBilancoOnGetDonukResultQuery, GenericResult<AktarmaDashBilancoOnGetDonukResultResponse>>
{

    public Task<GenericResult<AktarmaDashBilancoOnGetDonukResultResponse>> Handle(AktarmaDashBilancoOnGetDonukResultQuery request, CancellationToken cancellationToken)
    { 
            var dashMizanResultAktarma = companiesManager.GetCompanyAktarmaDonuk(request.Request.compid, request.Request.nyear);
            request.InitialModel.DashMizanResultAktarma = dashMizanResultAktarma;
            
            return Task.FromResult(GenericResult<AktarmaDashBilancoOnGetDonukResultResponse>.Success(
                new AktarmaDashBilancoOnGetDonukResultResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(dashMizanResultAktarma, options: request.Request.options)),
                    InitialModel = request.InitialModel
                }));
       
    }
}
