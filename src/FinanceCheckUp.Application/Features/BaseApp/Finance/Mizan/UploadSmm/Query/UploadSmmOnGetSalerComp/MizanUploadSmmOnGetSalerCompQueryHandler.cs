using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadSmm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadSmm.Query.UploadSmmOnGetSalerComp
{
    public class MizanUploadSmmOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUploadSmmOnGetSalerCompQuery, GenericResult<MizanUploadSmmOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanUploadSmmOnGetSalerCompResponse>> Handle(MizanUploadSmmOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId); 
                        return Task.FromResult(GenericResult<MizanUploadSmmOnGetSalerCompResponse>.Success(new MizanUploadSmmOnGetSalerCompResponse
            {
                Response = DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options)
            }));
        }
    }
}
