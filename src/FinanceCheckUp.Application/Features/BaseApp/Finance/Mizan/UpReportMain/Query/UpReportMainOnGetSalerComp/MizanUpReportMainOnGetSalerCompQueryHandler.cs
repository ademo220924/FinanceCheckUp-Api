using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpReportMain.Query.UpReportMainOnGetSalerComp
{
    public class MizanUpReportMainOnGetSalerCompQueryHandler(
        ICompanyManager companyManager) : IRequestHandler<MizanUpReportMainOnGetSalerCompQuery, GenericResult<MizanUpReportMainOnGetSalerCompResponse>>
    {

        public Task<GenericResult<MizanUpReportMainOnGetSalerCompResponse>> Handle(MizanUpReportMainOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
                        return Task.FromResult(GenericResult<MizanUpReportMainOnGetSalerCompResponse>.Success(new MizanUpReportMainOnGetSalerCompResponse
            {
                Response = DataSourceLoader.Load(companyManager.Getby_User(userId), request.Request.options)
            }));
        }
    }
}
