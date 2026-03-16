using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaJrnl.Query.UpPageAktarmaJrnlOnGetSalerComp;
public class MizanUpPageAktarmaJrnlOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaJrnlOnGetSalerCompQuery, GenericResult<MizanUpPageAktarmaJrnlOnGetSalerCompResponse>>
{
 

    public Task<GenericResult<MizanUpPageAktarmaJrnlOnGetSalerCompResponse>> Handle(MizanUpPageAktarmaJrnlOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(userId);
         
        var mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID );
          
        return Task.FromResult(GenericResult<MizanUpPageAktarmaJrnlOnGetSalerCompResponse>.Success(
            new MizanUpPageAktarmaJrnlOnGetSalerCompResponse
            {
                InitialModel = request.InitialModel,
                Response=new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.options))
            }));
    }
}
