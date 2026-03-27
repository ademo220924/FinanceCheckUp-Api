using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetGraphZet;
public class FinanceFinanceHrtViewOnGetGraphZetQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    IMainDashManager mainDashManager) : IRequestHandler<FinanceFinanceHrtViewOnGetGraphZetQuery, GenericResult<FinanceFinanceHrtViewOnGetGraphZetResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetGraphZetResponse>> Handle(FinanceFinanceHrtViewOnGetGraphZetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.InitialModel.CompID, (int)userId))
        {
                        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetGraphZetResponse>.Success(new FinanceFinanceHrtViewOnGetGraphZetResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));

        }

        var retval = mainDashManager.Get_Data(request.Request.myear, request.InitialModel.CompID);

                return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetGraphZetResponse>.Success(new FinanceFinanceHrtViewOnGetGraphZetResponse
        {
            Response = DataSourceLoader.Load(retval, request.Request.options)
        }));

    }
}
