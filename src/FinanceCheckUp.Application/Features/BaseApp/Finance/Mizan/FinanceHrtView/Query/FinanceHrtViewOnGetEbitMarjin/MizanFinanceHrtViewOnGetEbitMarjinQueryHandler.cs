using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetEbitMarjin;
public class MizanFinanceHrtViewOnGetEbitMarjinQueryHandler(IReportDashManager  sagaReportDashManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetEbitMarjinQuery, GenericResult<MizanFinanceHrtViewOnGetEbitMarjinResponse>>
{
    public Task<GenericResult<MizanFinanceHrtViewOnGetEbitMarjinResponse>> Handle(MizanFinanceHrtViewOnGetEbitMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
                        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetEbitMarjinResponse>.Success(
                new MizanFinanceHrtViewOnGetEbitMarjinResponse
                {
                    Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
                }));
            
        }

        var retval = sagaReportDashManager.Get_Data_EbitMarjin(request.Request.myear, request.Request.compid);
       
                return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetEbitMarjinResponse>.Success(
            new MizanFinanceHrtViewOnGetEbitMarjinResponse
            {
                Response = DataSourceLoader.Load(retval, request.Request.options)
            }));
    }
}
