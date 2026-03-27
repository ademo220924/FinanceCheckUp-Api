using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.dashbilancomain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.dashbilancomain.Query.dashbilancomainOnGetMarkupMarjin;
public class AktarmaDashbilancomainOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) 
    : IRequestHandler<AktarmaDashbilancomainOnGetMarkupMarjinQuery, GenericResult<AktarmaDashbilancomainOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<AktarmaDashbilancomainOnGetMarkupMarjinResponse>> Handle(AktarmaDashbilancomainOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var dashBilancoViewMultiList = new List<DashBilancoViewMulti>();
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<AktarmaDashbilancomainOnGetMarkupMarjinResponse>.Success(
                new AktarmaDashbilancomainOnGetMarkupMarjinResponse
                {
                    InitialModel = request.InitialModel,
                    Result = DataSourceLoader.Load(dashBilancoViewMultiList, request.Request.options)
                }));
        }


        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktMulti(request.Request.compid);

        return Task.FromResult(GenericResult<AktarmaDashbilancomainOnGetMarkupMarjinResponse>.Success(
            new AktarmaDashbilancomainOnGetMarkupMarjinResponse
            {
                InitialModel = request.InitialModel,
                Result = DataSourceLoader.Load(
                    request.InitialModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options)
            }));
    }
}