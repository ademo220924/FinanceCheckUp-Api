using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUploadOneGoOn;

public class MoodUploadOneGoOnCommandHandler(
    ICompanyManager companyManager,
    IXmlCheckerManager xmlCheckerManager,
    IERRLOGManager errlogManager)
    : IRequestHandler<MoodUploadOneGoOnCommand, GenericResult<MoodUploadOneGoOnResponse>>
{
    public Task<GenericResult<MoodUploadOneGoOnResponse>> Handle(MoodUploadOneGoOnCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUploadOneGoOnRequest.PageIndex;
        var comp = companyManager.Get_Company(Convert.ToInt32(pageIndex.ide));
        string filemonth = pageIndex.Caption.Split('_')[0];
        string fileyear = pageIndex.Caption.Split('_')[1];

        try
        {
            string retval = xmlCheckerManager.SapEntegratorSetUpon(comp.Id, filemonth, fileyear, Convert.ToInt32(pageIndex.idexml));

            return Task.FromResult(GenericResult<MoodUploadOneGoOnResponse>.Success(
                new MoodUploadOneGoOnResponse { ResultText = new JsonResult(retval) }));
        }
        catch (Exception ex)
        {
            errlogManager.Save_AppLogs(new ERRLOG
            {
                CompanyID = comp.Id,
                CsvID = 7777,
                ERLOG = ex.ToString()
            });
            return Task.FromResult(GenericResult<MoodUploadOneGoOnResponse>.Success(
                new MoodUploadOneGoOnResponse { ResultText = new JsonResult("nok") }));
        }
    }
}
