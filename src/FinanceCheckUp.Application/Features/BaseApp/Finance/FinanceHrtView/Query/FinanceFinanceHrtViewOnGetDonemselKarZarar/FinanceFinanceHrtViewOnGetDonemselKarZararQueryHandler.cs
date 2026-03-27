using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetDonemselKarZarar;
public class FinanceFinanceHrtViewOnGetDonemselKarZararQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    IReportDashManager reportDashManager) : IRequestHandler<FinanceFinanceHrtViewOnGetDonemselKarZararQuery, GenericResult<FinanceFinanceHrtViewOnGetDonemselKarZararResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetDonemselKarZararResponse>> Handle(FinanceFinanceHrtViewOnGetDonemselKarZararQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.InitialModel.CompID, (int)userId))
        {

                        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetDonemselKarZararResponse>.Success(new FinanceFinanceHrtViewOnGetDonemselKarZararResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        }

        var retval = reportDashManager.Get_Data_DonemselKarzarar(request.Request.myear, request.InitialModel.CompID);

                return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetDonemselKarZararResponse>.Success(new FinanceFinanceHrtViewOnGetDonemselKarZararResponse
        {
            Response = DataSourceLoader.Load(retval, request.Request.options)
        }));

    }
}
