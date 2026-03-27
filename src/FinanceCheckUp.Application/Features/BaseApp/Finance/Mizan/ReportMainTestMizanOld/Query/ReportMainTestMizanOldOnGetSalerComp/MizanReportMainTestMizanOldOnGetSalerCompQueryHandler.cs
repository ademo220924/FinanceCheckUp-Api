using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizanOld.Query.ReportMainTestMizanOldOnGetSalerComp
{
    public class MizanReportMainTestMizanOldOnGetSalerCompQueryHandler(ICompanyManager companyManager) 
        : IRequestHandler<MizanReportMainTestMizanOldOnGetSalerCompQuery, GenericResult<MizanReportMainTestMizanOldOnGetSalerCompResponse>>
    {
        public Task<GenericResult<MizanReportMainTestMizanOldOnGetSalerCompResponse>> Handle(MizanReportMainTestMizanOldOnGetSalerCompQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
            
                        return Task.FromResult(GenericResult<MizanReportMainTestMizanOldOnGetSalerCompResponse>.Success(new MizanReportMainTestMizanOldOnGetSalerCompResponse
            {
                InitialModel = request.InitialModel,
                Response=DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options)
            }));
        }
    }
}
