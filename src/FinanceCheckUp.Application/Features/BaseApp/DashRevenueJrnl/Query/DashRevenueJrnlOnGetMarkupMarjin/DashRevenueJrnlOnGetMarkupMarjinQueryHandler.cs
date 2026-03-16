using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenueJrnl.Query.DashRevenueJrnlOnGetMarkupMarjin;
public class DashRevenueJrnlOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<DashRevenueJrnlOnGetMarkupMarjinQuery, GenericResult<DashRevenueJrnlOnGetMarkupMarjinResponse>>
{

    public async Task<GenericResult<DashRevenueJrnlOnGetMarkupMarjinResponse>> Handle(DashRevenueJrnlOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (request.Request.Compid < 1)
            return GenericResult<DashRevenueJrnlOnGetMarkupMarjinResponse>.Success(new DashRevenueJrnlOnGetMarkupMarjinResponse { Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.Options)) });

        var nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMultiJRNL(request.Request.Compid);

        return GenericResult<DashRevenueJrnlOnGetMarkupMarjinResponse>.Success(new DashRevenueJrnlOnGetMarkupMarjinResponse { Response = new JsonResult(DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.Options)) });
    }
}