using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.CashFlow;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetMarkupMarjin;
public class FinanceCashFlowOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosu,
    IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, 
    IUserTypeManager userTypeManager, 
    ICompanyManager companyManager, 
    ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceCashFlowOnGetMarkupMarjinQuery, GenericResult<FinanceCashFlowOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceCashFlowOnGetMarkupMarjinResponse>> Handle(FinanceCashFlowOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var userId = Convert.ToInt64(request.UserId);
        var chk = dashGelirTablosu.Get_MAINRESULTMultiCashFlow(request.InitialModel.CompID);
        if (chk.Count < 1)
        {
            return Task.FromResult(GenericResult<FinanceCashFlowOnGetMarkupMarjinResponse>.Success(new FinanceCashFlowOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(chk, request.Request.options),
                InitialModel = request.InitialModel
            }));
        }

        return Task.FromResult(GenericResult<FinanceCashFlowOnGetMarkupMarjinResponse>.Success(new FinanceCashFlowOnGetMarkupMarjinResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options),
            InitialModel = request.InitialModel
        }));

    }
}
