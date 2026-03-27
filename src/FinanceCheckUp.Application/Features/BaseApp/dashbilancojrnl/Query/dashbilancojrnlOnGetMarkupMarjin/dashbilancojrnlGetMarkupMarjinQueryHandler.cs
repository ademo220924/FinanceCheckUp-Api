using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.dashbilancojrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancojrnl.Query.dashbilancojrnlOnGetMarkupMarjin;
public class dashbilancojrnlOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancojrnlOnGetMarkupMarjinQuery, GenericResult<dashbilancojrnlOnGetMarkupMarjinResponse>>
{

    public async Task<GenericResult<dashbilancojrnlOnGetMarkupMarjinResponse>> Handle(dashbilancojrnlOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);

        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (request.Request.compid < 1) 
            return GenericResult<dashbilancojrnlOnGetMarkupMarjinResponse>.Success(new dashbilancojrnlOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });

        var nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktMultiJRNL(request.Request.compid); 
        return GenericResult<dashbilancojrnlOnGetMarkupMarjinResponse>.Success(new dashbilancojrnlOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.DataSourceLoadOptions) });
    }
}