using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGetChartRasyo;
public class DashBilancoOnGetChartRasyoQueryHandler : IRequestHandler<DashBilancoOnGetChartRasyoQuery, GenericResult<DashBilancoOnGetChartRasyoResponse>>
{

    public async Task<GenericResult<DashBilancoOnGetChartRasyoResponse>> Handle(DashBilancoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var ncart = new DashYearlyBilancoChart();
        ncart.SetResult(request.RequestModel.InitialModel.nRequestList, request.RequestModel.InitialModel.CurrentUser.SelectedYear);
                return GenericResult<DashBilancoOnGetChartRasyoResponse>.Success(new DashBilancoOnGetChartRasyoResponse { Result = DataSourceLoader.Load(ncart.nresult, options: request.RequestModel.DataSourceLoadOptions) });
    }
}