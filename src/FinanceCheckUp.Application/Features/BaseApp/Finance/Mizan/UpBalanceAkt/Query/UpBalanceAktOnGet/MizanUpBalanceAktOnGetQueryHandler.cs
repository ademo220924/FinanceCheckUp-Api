using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceAkt;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceAkt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceAkt.Query.UpBalanceAktOnGet
{
    public class MizanUpBalanceAktOnGetQueryHandler(
        IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager) : IRequestHandler<MizanUpBalanceAktOnGetQuery, GenericResult<MizanUpBalanceAktOnGetResponse>>
    {
        public Task<GenericResult<MizanUpBalanceAktOnGetResponse>> Handle(MizanUpBalanceAktOnGetQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUpBalanceAktRequestInitialModel
            {
                UserID = userId,
                mreqListCompany = companyManager.Getby_User(userId)
            };
            
            responseModel.CCompanies = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();
            responseModel.CompID = responseModel.CCompanies.Id;
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilancoAkt( request.Request.nyear, responseModel.CompID);
            responseModel.header = responseModel.CCompanies.CompanyName + " " + request.Request.nyear.ToString() + " Yılı Aktarma Karşılaştırmalı Mizan Raporu";

            if (responseModel.CompID == 14)
            {

            }
            
            return Task.FromResult(GenericResult<MizanUpBalanceAktOnGetResponse>.Success(
                new MizanUpBalanceAktOnGetResponse
                {
                    InitialModel = responseModel
                }));
        }
    }
}
