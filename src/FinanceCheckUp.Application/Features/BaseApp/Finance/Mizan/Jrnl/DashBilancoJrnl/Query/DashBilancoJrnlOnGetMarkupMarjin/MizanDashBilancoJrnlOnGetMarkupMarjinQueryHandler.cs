using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoJrnl;
using FinanceCheckUp.Application.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.DashBilancoJrnl.Query.DashBilancoJrnlOnGetMarkupMarjin;
public class MizanDashBilancoJrnlOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanDashBilancoJrnlOnGetMarkupMarjinQuery, GenericResult<MizanDashBilancoJrnlOnGetMarkupMarjinResponse>>
{
    
    public Task<GenericResult<MizanDashBilancoJrnlOnGetMarkupMarjinResponse>> Handle(MizanDashBilancoJrnlOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (request.Request.compid< 1)
        {
           
            return Task.FromResult(GenericResult<MizanDashBilancoJrnlOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoJrnlOnGetMarkupMarjinResponse
                {
                    InitialModel = request.InitialModel,
                    Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
                }));
        }
 
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktMultiJRNL(request.Request.compid);
        return Task.FromResult(GenericResult<MizanDashBilancoJrnlOnGetMarkupMarjinResponse>.Success(
            new MizanDashBilancoJrnlOnGetMarkupMarjinResponse
            {
                InitialModel = request.InitialModel,
                Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options))
            }));
        
    }
}
