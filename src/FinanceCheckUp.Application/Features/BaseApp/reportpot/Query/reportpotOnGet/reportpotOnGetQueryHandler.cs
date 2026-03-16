using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.reportpot;
using FinanceCheckUp.Application.Models.Responses.reportpot;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.reportpot.Query.reportpotOnGet;
public class reportpotOnGetQueryHandler(IMainDashManager mainDashManager, IErrorCheckMainManager errorCheckMainManager) : IRequestHandler<reportpotOnGetQuery, GenericResult<reportpotOnGetResponse>>
{

    public async Task<GenericResult<reportpotOnGetResponse>> Handle(reportpotOnGetQuery request, CancellationToken cancellationToken)
    {
        var responseModel = new reportpotRequest();
        var UserID = Convert.ToInt64(request.UserId);


        var ncheck = mainDashManager.DataViewerMainSourceT(request.Request.nyear, request.Request.nmon, request.Request.nmont);
        var ncheckMain = errorCheckMainManager.Get_ReportSetAll(request.Request.nyear, request.Request.nmon, request.Request.nmont);

        ncheck.AddRange(ncheckMain);

        responseModel.ncheck = ncheck.Distinct().OrderBy(c => c.EntryNumber).ThenBy(n => n.Description).ToList();

        responseModel.ncheckMain = ncheckMain;

        return GenericResult<reportpotOnGetResponse>.Success(new reportpotOnGetResponse { InitialModel = responseModel });
    }
}