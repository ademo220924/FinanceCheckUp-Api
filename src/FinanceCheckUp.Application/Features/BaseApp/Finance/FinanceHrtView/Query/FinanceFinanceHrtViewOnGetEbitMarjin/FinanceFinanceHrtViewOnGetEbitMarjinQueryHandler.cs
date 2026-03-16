using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetEbitMarjin;
public class FinanceFinanceHrtViewOnGetEbitMarjinQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    IReportDashManager reportDashManager) : IRequestHandler<FinanceFinanceHrtViewOnGetEbitMarjinQuery, GenericResult<FinanceFinanceHrtViewOnGetEbitMarjinResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetEbitMarjinResponse>> Handle(FinanceFinanceHrtViewOnGetEbitMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.InitialModel.CompID, (int)userId))
        {
            return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetEbitMarjinResponse>.Success(new FinanceFinanceHrtViewOnGetEbitMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
            }));

        }

        var retval = reportDashManager.Get_Data_EbitMarjin(request.Request.myear, request.InitialModel.CompID);

        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetEbitMarjinResponse>.Success(new FinanceFinanceHrtViewOnGetEbitMarjinResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(retval, request.Request.options))
        }));

    }
}
