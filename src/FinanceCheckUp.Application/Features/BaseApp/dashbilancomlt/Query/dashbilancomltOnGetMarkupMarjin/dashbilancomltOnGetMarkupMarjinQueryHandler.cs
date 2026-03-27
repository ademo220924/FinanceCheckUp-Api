using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetMarkupMarjin;
public class dashbilancomltOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancomltOnGetMarkupMarjinQuery, GenericResult<dashbilancomltOnGetMarkupMarjinResponse>>
{

    public async Task<GenericResult<dashbilancomltOnGetMarkupMarjinResponse>> Handle(dashbilancomltOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (string.IsNullOrEmpty(request.Request.myear))
            
            return GenericResult<dashbilancomltOnGetMarkupMarjinResponse>.Success(new dashbilancomltOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });

        string[] llist = request.Request.myear.Split(',');
        if (llist.Length < 0) 
            return GenericResult<dashbilancomltOnGetMarkupMarjinResponse>.Success(new dashbilancomltOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });


        var tt = llist.Select(int.Parse).ToList();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMulti(tt.ToArray(), request.Request.compid);
        return GenericResult<dashbilancomltOnGetMarkupMarjinResponse>.Success(new dashbilancomltOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });
    }
}