using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetSalerMain
{
    internal class GetSalerMainQueryHandle(IDataManager dataManager) : IRequestHandler<GetSalerMainQuery, GenericResult<GetSalerMainResponseModel>>
    {
        public async Task<GenericResult<GetSalerMainResponseModel>> Handle(GetSalerMainQuery request, CancellationToken cancellationToken)
        {
            var dt1 = "105";
            var winModelTlist = dataManager.Get_AllbyCsvID(dt1);
            return GenericResult<GetSalerMainResponseModel>.Success(new GetSalerMainResponseModel { Result = new JsonResult(DataSourceLoader.Load(winModelTlist, request.RequestModel.Options)) });
        }
    }
}
