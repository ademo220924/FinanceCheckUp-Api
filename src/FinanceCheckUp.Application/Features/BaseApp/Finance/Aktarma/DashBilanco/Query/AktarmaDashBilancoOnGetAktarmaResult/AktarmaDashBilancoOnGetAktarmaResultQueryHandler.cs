using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetAktarmaResult;
public class AktarmaDashBilancoOnGetAktarmaResultQueryHandler(ICompanyManager companiesManager) 
    : IRequestHandler<AktarmaDashBilancoOnGetAktarmaResultQuery, GenericResult<AktarmaDashBilancoOnGetAktarmaResultResponse>>
{
    public Task<GenericResult<AktarmaDashBilancoOnGetAktarmaResultResponse>> Handle(AktarmaDashBilancoOnGetAktarmaResultQuery request, CancellationToken cancellationToken)
    {
       var  dashMizanResultAktarma = companiesManager.GetCompanyAktarmaResult(request.Request.compid, request.Request.nyear);

       request.InitialModel.DashMizanResultAktarma = dashMizanResultAktarma;
       
        return Task.FromResult(GenericResult<AktarmaDashBilancoOnGetAktarmaResultResponse>.Success(
            new AktarmaDashBilancoOnGetAktarmaResultResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(dashMizanResultAktarma.ToList(), request.Request.options)),
                InitialModel = request.InitialModel
            }));
    }
}