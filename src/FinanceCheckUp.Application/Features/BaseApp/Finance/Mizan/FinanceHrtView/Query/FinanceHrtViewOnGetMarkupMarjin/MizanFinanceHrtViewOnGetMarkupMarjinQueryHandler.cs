using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetMarkupMarjin;
public class MizanFinanceHrtViewOnGetMarkupMarjinQueryHandler(IReportDashManager reportDashManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetMarkupMarjinQuery, GenericResult<MizanFinanceHrtViewOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanFinanceHrtViewOnGetMarkupMarjinResponse>> Handle(MizanFinanceHrtViewOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);


        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
     
                        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetMarkupMarjinResponse>.Success(
                new MizanFinanceHrtViewOnGetMarkupMarjinResponse
                {
                    Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
                })); 
        }


        var mrequestResult= reportDashManager.Get_Data_GrossProfitGraphic(request.Request.myear, request.Request.compid);

 
                return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetMarkupMarjinResponse>.Success(
            new MizanFinanceHrtViewOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(mrequestResult, request.Request.options)
            })); 
    }
}
