using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Konsol.DashRevenueKon.Query.DashRevenueKonOnGetMarkupMarjin;
public class DashRevenueKonOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<DashRevenueKonOnGetMarkupMarjinQuery, GenericResult<DashRevenueKonOnGetMarkupMarjinResponse>>
{

    public Task<GenericResult<DashRevenueKonOnGetMarkupMarjinResponse>> Handle(DashRevenueKonOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        
        if (request.Request.compid < 1)
        {
                        return Task.FromResult(GenericResult<DashRevenueKonOnGetMarkupMarjinResponse>.Success(
                new DashRevenueKonOnGetMarkupMarjinResponse
                {
                    Response = DataSourceLoader.Load(new List<DashBilancoViewMulti>(), request.Request.options),
                    InitialModel = request.InitialModel
                }));
        }


        var nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMultiKon(request.Request.compid);
        request.InitialModel.nRequestList = nRequestList;
        
        
                return Task.FromResult(GenericResult<DashRevenueKonOnGetMarkupMarjinResponse>.Success(
            new DashRevenueKonOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.options)
            }));
    }
}


