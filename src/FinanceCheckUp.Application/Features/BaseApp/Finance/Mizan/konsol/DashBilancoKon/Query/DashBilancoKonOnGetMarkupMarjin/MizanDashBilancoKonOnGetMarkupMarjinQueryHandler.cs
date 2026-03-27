using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Models;
using Microsoft.Extensions.Options;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashBilancoKon;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.konsol.DashBilancoKon.Query.DashBilancoKonOnGetMarkupMarjin;
public class MizanDashBilancoKonOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager gelirTablosuManager) 
    : IRequestHandler<MizanDashBilancoKonOnGetMarkupMarjinQuery, GenericResult<MizanDashBilancoKonOnGetMarkupMarjinResponse>>
{
 

    public Task<GenericResult<MizanDashBilancoKonOnGetMarkupMarjinResponse>> Handle(MizanDashBilancoKonOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanDashBilancoKonRequestInitialModel
        {
            UserID = userId
        }; 

        var chklist = new List<DashBilancoViewMulti>();
        if (request.Request.compid < 1)
        {
                          return Task.FromResult(GenericResult<MizanDashBilancoKonOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoKonOnGetMarkupMarjinResponse
                {
                    InitialModel = responseModel,
                    Response =  DataSourceLoader.Load(chklist, request.Request.options)
                }));
        }



        responseModel.nRequestList = gelirTablosuManager.Get_MAINBilancoMznAktMultiKon(request.Request.compid);

                return Task.FromResult(GenericResult<MizanDashBilancoKonOnGetMarkupMarjinResponse>.Success(
            new MizanDashBilancoKonOnGetMarkupMarjinResponse
            {
                InitialModel = responseModel,
                Response = DataSourceLoader.Load(responseModel.nRequestList.Where(x => x.IsHidden == 0), request.Request.options)
            }));
            
      
        
    }
}
