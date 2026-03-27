using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashWorkingCapital.Query.DashWorkingCapitalOnGetMarkupMarjin;
public class MizanDashWorkingCapitalOnGetMarkupMarjinQueryHandler(IDashWCapitalMizanManager dashWCapitalMizanManager) : IRequestHandler<MizanDashWorkingCapitalOnGetMarkupMarjinQuery, GenericResult<MizanDashWorkingCapitalOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanDashWorkingCapitalOnGetMarkupMarjinResponse>> Handle(MizanDashWorkingCapitalOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        request.InitialModel.nRequestList = dashWCapitalMizanManager.Get_getDataWcapFINALMain(request.Request.compid);
         
        
                return Task.FromResult(GenericResult<MizanDashWorkingCapitalOnGetMarkupMarjinResponse>.Success(
            new MizanDashWorkingCapitalOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(request.InitialModel.nRequestList, request.Request.options),
                InitialModel = request.InitialModel
            }));
    }
}