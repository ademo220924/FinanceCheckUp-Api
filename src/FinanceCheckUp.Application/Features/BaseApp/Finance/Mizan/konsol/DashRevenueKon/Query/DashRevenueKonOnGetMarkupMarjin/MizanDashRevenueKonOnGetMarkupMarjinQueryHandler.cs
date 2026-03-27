using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashRevenueKon.Query.DashRevenueKonOnGetMarkupMarjin;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Konsol.DashRevenueKon.Query.DashRevenueKonOnGetMarkupMarjin;
public class MizanDashRevenueKonOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) 
    : IRequestHandler<MizanDashRevenueKonOnGetMarkupMarjinQuery, GenericResult<MizanDashRevenueKonOnGetMarkupMarjinResponse>>
{
    
    public Task<GenericResult<MizanDashRevenueKonOnGetMarkupMarjinResponse>> Handle(MizanDashRevenueKonOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashRevenueKonRequestInitialModel
        {
            UserID = userId
        }; 

        var chklist = new List<DashBilancoViewMulti>();
        if (request.Request.compid< 1)
        {
                        return Task.FromResult(GenericResult<MizanDashRevenueKonOnGetMarkupMarjinResponse>.Success(
                new MizanDashRevenueKonOnGetMarkupMarjinResponse
                {
                    InitialModel = responseModel,
                    Response =  DataSourceLoader.Load(chklist, request.Request.options)
                }));
             
        }
        
        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMultiKon(request.Request.compid);
                return Task.FromResult(GenericResult<MizanDashRevenueKonOnGetMarkupMarjinResponse>.Success(
            new MizanDashRevenueKonOnGetMarkupMarjinResponse
            {
                InitialModel = responseModel,
                Response = DataSourceLoader.Load(responseModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options)
            })); 
    }
}


