using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashBilanco.Query.DashBilancoOnGetMarkupMarjin;

public class MizanAktarmaDashBilancoOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) 
    : IRequestHandler<MizanAktarmaDashBilancoOnGetMarkupMarjinQuery, GenericResult<MizanAktarmaDashBilancoOnGetMarkupMarjinResponse>>
{

    public Task<GenericResult<MizanAktarmaDashBilancoOnGetMarkupMarjinResponse>> Handle(MizanAktarmaDashBilancoOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<MizanAktarmaDashBilancoOnGetMarkupMarjinResponse>.Success(
                new MizanAktarmaDashBilancoOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<DashBilancoViewMulti>(), request.Request.options)),
                    InitialModel = request.InitialModel
                }));
        }


        var nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktMulti(request.Request.compid);
        request.InitialModel.nRequestList = nRequestList;
        
        return Task.FromResult(GenericResult<MizanAktarmaDashBilancoOnGetMarkupMarjinResponse>.Success(
            new MizanAktarmaDashBilancoOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.options)),
                InitialModel = request.InitialModel
            }));
        
       
    }
}