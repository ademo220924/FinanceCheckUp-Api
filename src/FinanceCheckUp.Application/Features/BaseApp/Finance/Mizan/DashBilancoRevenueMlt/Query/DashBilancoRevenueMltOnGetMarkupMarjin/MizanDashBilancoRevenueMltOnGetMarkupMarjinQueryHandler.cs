using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueMlt;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGetMarkupMarjin;

public class MizanDashBilancoRevenueMltOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager)
    : IRequestHandler<MizanDashBilancoRevenueMltOnGetMarkupMarjinQuery, GenericResult<MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse>>
{
    
    public Task<GenericResult<MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse>> Handle(MizanDashBilancoRevenueMltOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var chklist = new List<DashBilancoViewMulti>();
        if (string.IsNullOrEmpty(request.Request.myear))
        {
            return Task.FromResult(GenericResult<MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
                }));
        }


        var list = request.Request.myear.Split(',');
        if (list.Length < 0)
        {
            return Task.FromResult(GenericResult<MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
                }));
        }

        var tt = list.Select(int.Parse).ToList();
        chklist = dashGelirTablosuManager.Get_MAINRESULTMultiRVN(tt.ToArray(), request.Request.compid);

        return Task.FromResult(GenericResult<MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse>.Success(
            new MizanDashBilancoRevenueMltOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
            }));
    }
}