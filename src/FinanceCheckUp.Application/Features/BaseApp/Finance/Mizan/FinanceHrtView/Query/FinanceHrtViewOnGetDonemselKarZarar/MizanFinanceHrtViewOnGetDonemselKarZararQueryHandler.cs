using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetDonemselKarZarar;
public class MizanFinanceHrtViewOnGetDonemselKarZararQueryHandler(IReportDashManager reportDashManager,IHhvnUsersManager hhvnUsersManager,  IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetDonemselKarZararQuery, GenericResult<MizanFinanceHrtViewOnGetDonemselKarZararResponse>>
{

    public Task<GenericResult<MizanFinanceHrtViewOnGetDonemselKarZararResponse>> Handle(MizanFinanceHrtViewOnGetDonemselKarZararQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            
            return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetDonemselKarZararResponse>.Success(
                new MizanFinanceHrtViewOnGetDonemselKarZararResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
                }));
        }

        var retval = reportDashManager.Get_Data_DonemselKarzarar(request.Request.myear, request.Request.compid);
            
        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetDonemselKarZararResponse>.Success(
            new MizanFinanceHrtViewOnGetDonemselKarZararResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
            }));
    }
}
