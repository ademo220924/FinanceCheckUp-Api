using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using FinanceCheckUp.Application.Models;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl.Query.DashBilancoRevenueJrnlOnGetMarkupMarjin;

public class MizanDashBilancoRevenueJrnlOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanDashBilancoRevenueJrnlOnGetMarkupMarjinQuery, GenericResult<MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse>> Handle(MizanDashBilancoRevenueJrnlOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (request.Request.compid < 1)
        {
                        return Task.FromResult(GenericResult<MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse
                {
                    InitialModel = request.InitialModel,
                    Response = DataSourceLoader.Load(chklist, request.Request.options)
                }));
        }
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMultiJRNL(request.Request.compid);

                return Task.FromResult(GenericResult<MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse>.Success(
            new MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(request.InitialModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options)
            }));
         
    }
}

