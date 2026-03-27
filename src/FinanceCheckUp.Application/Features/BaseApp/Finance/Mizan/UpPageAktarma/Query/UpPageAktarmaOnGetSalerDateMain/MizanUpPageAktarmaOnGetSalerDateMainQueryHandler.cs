using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetSalerDateMain
{
    public class MizanUpPageAktarmaOnGetSalerDateMainQueryHandler(
        IDashAktarmaSqlOperationManager dashAktarmaSqlOperationManager,
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager) 
        : IRequestHandler<MizanUpPageAktarmaOnGetSalerDateMainQuery, GenericResult<MizanUpPageAktarmaOnGetSalerDateMainResponse>>
    {
        public Task<GenericResult<MizanUpPageAktarmaOnGetSalerDateMainResponse>> Handle(MizanUpPageAktarmaOnGetSalerDateMainQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

            var currentUploadM1 = setMainSqlOperationManager.Get_CompanyAktarmaResult(request.Request.nyear, request.InitialModel.curcomID);
            var currentUploadM = dashAktarmaSqlOperationManager.AddSMMM(currentUploadM1);
            var options = new DataSourceLoadOptions();
 
            
                        return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetSalerDateMainResponse>.Success(new MizanUpPageAktarmaOnGetSalerDateMainResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(currentUploadM, options)
            }));
        }
    }
}
