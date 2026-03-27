using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerDate;
public class MizanUpPageAktarmaJrnlOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetSalerDateQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateResponse>>
{
 
    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateResponse>> Handle(MizanUpPageAktarmaJrnlOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(userId);

        
        
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyAktarmaMizan(request.InitialModel.curcomID);

                return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetSalerDateResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
            }));
    }
}

