using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetMarkupMarjin;
public class dashbilancorvnmltOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<dashbilancorvnmltOnGetMarkupMarjinQuery, GenericResult<dashbilancorvnmltOnGetMarkupMarjinResponse>>
{

    public async Task<GenericResult<dashbilancorvnmltOnGetMarkupMarjinResponse>> Handle(dashbilancorvnmltOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        if (string.IsNullOrEmpty(request.Request.myear))
            return GenericResult<dashbilancorvnmltOnGetMarkupMarjinResponse>.Success(new dashbilancorvnmltOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });


        string[] llist = request.Request.myear.Split(',');
        if (llist.Length < 0)
            return GenericResult<dashbilancorvnmltOnGetMarkupMarjinResponse>.Success(new dashbilancorvnmltOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });

        var tt = llist.Select(int.Parse).ToList();

        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiRVN(tt.ToArray(), request.Request.compid);
        return GenericResult<dashbilancorvnmltOnGetMarkupMarjinResponse>.Success(new dashbilancorvnmltOnGetMarkupMarjinResponse { Result = DataSourceLoader.Load(chklist, request.Request.DataSourceLoadOptions) });
    }
}