using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetGraphZet;
public class MizanFinanceHrtViewOnGetGraphZetQueryHandler(IMainDashManager mainDashManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetGraphZetQuery, GenericResult<MizanFinanceHrtViewOnGetGraphZetResponse>>
{
    public Task<GenericResult<MizanFinanceHrtViewOnGetGraphZetResponse>> Handle(MizanFinanceHrtViewOnGetGraphZetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
            return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetGraphZetResponse>.Success(
                new MizanFinanceHrtViewOnGetGraphZetResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
                }));
            
        }

        var retval = mainDashManager.Get_Data(request.Request.myear, request.Request.compid);
        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetGraphZetResponse>.Success(
            new MizanFinanceHrtViewOnGetGraphZetResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
            }));
       
    }
}
