using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashBilanco.Query.AktarmaDashBilancoOnGetMarkupMarjin;
public class AktarmaDashBilancoOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) 
    : IRequestHandler<AktarmaDashBilancoOnGetMarkupMarjinQuery, GenericResult<AktarmaDashBilancoOnGetMarkupMarjinResponse>>
{
    
    public Task<GenericResult<AktarmaDashBilancoOnGetMarkupMarjinResponse>> Handle(AktarmaDashBilancoOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var dashBilancoViewMultis = new List<DashBilancoViewMulti>();
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<AktarmaDashBilancoOnGetMarkupMarjinResponse>.Success(
                new AktarmaDashBilancoOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(dashBilancoViewMultis, request.Request.options)),
                    InitialModel = request.InitialModel
                }));
        }


        var nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktMulti(request.Request.compid);

        request.InitialModel.nRequestList = nRequestList;
        
        return Task.FromResult(GenericResult<AktarmaDashBilancoOnGetMarkupMarjinResponse>.Success(
            new AktarmaDashBilancoOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.options)),
                InitialModel = request.InitialModel
            }));
    }
}