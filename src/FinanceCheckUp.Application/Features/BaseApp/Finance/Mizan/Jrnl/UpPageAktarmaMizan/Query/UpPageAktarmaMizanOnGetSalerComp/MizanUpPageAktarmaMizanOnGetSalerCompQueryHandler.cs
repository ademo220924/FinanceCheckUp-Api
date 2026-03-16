using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGetSalerComp;

public class MizanUpPageAktarmaMizanOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaMizanOnGetSalerCompQuery, GenericResult<MizanUpPageAktarmaMizanOnGetSalerCompResponse>>
{
    
    public Task<GenericResult<MizanUpPageAktarmaMizanOnGetSalerCompResponse>> Handle(MizanUpPageAktarmaMizanOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
 
        request.InitialModel.UserID = userId;
        request.InitialModel.mreqListCompany = companyManager.Getby_User(request.InitialModel.UserID);
    
        return Task.FromResult(GenericResult<MizanUpPageAktarmaMizanOnGetSalerCompResponse>.Success(
            new MizanUpPageAktarmaMizanOnGetSalerCompResponse
            { 
                InitialModel =request.InitialModel,
                Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.mreqListCompany, request.Request.options))
            }));
    }
}



