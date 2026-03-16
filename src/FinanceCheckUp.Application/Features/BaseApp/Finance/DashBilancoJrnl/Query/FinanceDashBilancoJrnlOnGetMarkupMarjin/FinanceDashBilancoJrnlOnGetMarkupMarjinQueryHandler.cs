using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilancoJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilancoJrnl.Query.FinanceDashBilancoJrnlOnGetMarkupMarjin;
public class FinanceDashBilancoJrnlOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosu) : IRequestHandler<FinanceDashBilancoJrnlOnGetMarkupMarjinQuery, GenericResult<FinanceDashBilancoJrnlOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceDashBilancoJrnlOnGetMarkupMarjinResponse>> Handle(FinanceDashBilancoJrnlOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (request.Request.compid < 1)
        {

            return Task.FromResult(GenericResult<FinanceDashBilancoJrnlOnGetMarkupMarjinResponse>.Success(new FinanceDashBilancoJrnlOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
            }));
        }
        request.InitialModel.nRequestList = dashGelirTablosu.Get_MAINBilancoMznAktMultiJRNL(request.InitialModel.CompID);


        return Task.FromResult(GenericResult<FinanceDashBilancoJrnlOnGetMarkupMarjinResponse>.Success(new FinanceDashBilancoJrnlOnGetMarkupMarjinResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options))
        }));
    }
}
