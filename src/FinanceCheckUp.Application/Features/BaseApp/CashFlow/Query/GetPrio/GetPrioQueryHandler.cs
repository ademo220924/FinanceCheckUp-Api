using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetPrio
{
    public class GetPrioQueryHandler : IRequestHandler<GetPrioQuery, GenericResult<GetPrioResponseModel>>
    {
        public async Task<GenericResult<GetPrioResponseModel>> Handle(GetPrioQuery request, CancellationToken cancellationToken)
        {
                        return GenericResult<GetPrioResponseModel>.Success(new GetPrioResponseModel { Result = DataSourceLoader.Load(AppConst.PriorityResources, request.RequestModel.DataSourceLoadOptions) });
        }
    }
}
