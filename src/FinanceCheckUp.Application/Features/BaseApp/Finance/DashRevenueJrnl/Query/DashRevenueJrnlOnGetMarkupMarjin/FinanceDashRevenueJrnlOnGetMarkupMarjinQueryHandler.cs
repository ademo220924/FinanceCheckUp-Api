using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenueJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenueJrnl.Query.DashRevenueJrnlOnGetMarkupMarjin;
public class FinanceDashRevenueJrnlOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceDashRevenueJrnlOnGetMarkupMarjinQuery, GenericResult<FinanceDashRevenueJrnlOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceDashRevenueJrnlOnGetMarkupMarjinResponse>> Handle(FinanceDashRevenueJrnlOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (request.InitialModel.CompID < 1)
        {
            return Task.FromResult(GenericResult<FinanceDashRevenueJrnlOnGetMarkupMarjinResponse>.Success(new FinanceDashRevenueJrnlOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(chklist, request.Request.options)
            }));

        }

        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMultiJRNL(request.InitialModel.CompID);
        return Task.FromResult(GenericResult<FinanceDashRevenueJrnlOnGetMarkupMarjinResponse>.Success(new FinanceDashRevenueJrnlOnGetMarkupMarjinResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options)
        }));

    }
}
