using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashBilancoKon;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashBilancoKon.Query.DashBilancoKonOnGetMarkupMarjin;
public class DashBilancoKonOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) 
    : IRequestHandler<DashBilancoKonOnGetMarkupMarjinQuery, GenericResult<DashBilancoKonOnGetMarkupMarjinResponse>>
{

    public Task<GenericResult<DashBilancoKonOnGetMarkupMarjinResponse>> Handle(DashBilancoKonOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<DashBilancoKonOnGetMarkupMarjinResponse>.Success(
                new DashBilancoKonOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<DashBilancoViewMulti>(), request.Request.options)),
                    InitialModel = request.InitialModel
                }));
        }


        var nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktMultiKon(request.Request.compid);
        request.InitialModel.nRequestList = nRequestList;
        
        return Task.FromResult(GenericResult<DashBilancoKonOnGetMarkupMarjinResponse>.Success(
            new DashBilancoKonOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.options)),
                InitialModel = request.InitialModel
            }));
    }
}
