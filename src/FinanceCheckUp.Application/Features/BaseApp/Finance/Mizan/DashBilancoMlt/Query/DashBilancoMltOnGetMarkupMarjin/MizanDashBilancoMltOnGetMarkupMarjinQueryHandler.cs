using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoMlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoMlt.Query.DashBilancoMltOnGetMarkupMarjin;
public class MizanDashBilancoMltOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashBilancoMltOnGetMarkupMarjinQuery, GenericResult<MizanDashBilancoMltOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanDashBilancoMltOnGetMarkupMarjinResponse>> Handle(MizanDashBilancoMltOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var  chklist = new List<DashBilancoViewMulti>();
        if (string.IsNullOrEmpty(request.Request.myear))
        {
            return Task.FromResult(GenericResult<MizanDashBilancoMltOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoMltOnGetMarkupMarjinResponse
                {
                     
                    Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
                }));
        }


        var list = request.Request.myear.Split(',');
        if (list.Length < 0)
        {
            return Task.FromResult(GenericResult<MizanDashBilancoMltOnGetMarkupMarjinResponse>.Success(
                new MizanDashBilancoMltOnGetMarkupMarjinResponse
                {
                     
                    Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
                }));
        }
        var tt = list.Select(int.Parse).ToList();

        chklist = dashGelirTablosuManager.Get_MAINRESULTMulti(tt.ToArray(), request.Request.compid);
    
        return Task.FromResult(GenericResult<MizanDashBilancoMltOnGetMarkupMarjinResponse>.Success(
            new MizanDashBilancoMltOnGetMarkupMarjinResponse
            {
                     
                Response = new JsonResult(DataSourceLoader.Load(chklist, request.Request.options))
            }));
    }
}
