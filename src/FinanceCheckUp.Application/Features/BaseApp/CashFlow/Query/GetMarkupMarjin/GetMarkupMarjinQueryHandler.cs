using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetMarkupMarjin
{
    public class GetMarkupMarjinQueryHandle(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<GetMarkupMarjinQuery, GenericResult<GetMarkupMarjinResponseModel>>
    {
        public async Task<GenericResult<GetMarkupMarjinResponseModel>> Handle(GetMarkupMarjinQuery request, CancellationToken cancellationToken)
        {
            var chk = dashGelirTablosuManager.Get_MAINRESULTMultiCashFlow(request.RequestModel.Compid);
            if (chk.Count < 1)
            {
                List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
                return GenericResult<GetMarkupMarjinResponseModel>.Success(new GetMarkupMarjinResponseModel { Result = new JsonResult(DataSourceLoader.Load(chklist, request.RequestModel.DataSourceLoadOptions)) });
            }
            return GenericResult<GetMarkupMarjinResponseModel>.Success(new GetMarkupMarjinResponseModel { Result = new JsonResult(DataSourceLoader.Load(chk, request.RequestModel.DataSourceLoadOptions)) });
        }
    }
}
