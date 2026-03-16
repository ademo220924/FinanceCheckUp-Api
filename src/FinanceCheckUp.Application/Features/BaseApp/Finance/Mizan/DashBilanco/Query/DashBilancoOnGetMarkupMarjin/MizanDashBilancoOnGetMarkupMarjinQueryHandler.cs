using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilanco.Query.DashBilancoOnGetMarkupMarjin;
public class MizanDashBilancoOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashBilancoOnGetMarkupMarjinQuery, GenericResult<MizanDashBilancoOnGetMarkupMarjinResponse>>
{
     public Task<GenericResult<MizanDashBilancoOnGetMarkupMarjinResponse>> Handle(MizanDashBilancoOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    { 
        var chk = dashGelirTablosuManager
            .Get_MAINRESULTMultiMain(request.Request.compid)
            .Where(x => x.IsHidden == 0);
        
        return Task.FromResult(GenericResult<MizanDashBilancoOnGetMarkupMarjinResponse>.Success(
            new MizanDashBilancoOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
            }));
    }
}