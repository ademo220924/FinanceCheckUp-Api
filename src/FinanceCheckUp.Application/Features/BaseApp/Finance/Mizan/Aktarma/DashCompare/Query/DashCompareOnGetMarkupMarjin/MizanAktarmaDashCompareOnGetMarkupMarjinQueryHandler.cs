using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashCompare;
using FinanceCheckUp.Application.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashCompare.Query.DashCompareOnGetMarkupMarjin;

public class MizanAktarmaDashCompareOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanAktarmaashCompareOnGetMarkupMarjinQuery, GenericResult<MizanAktarmaDashCompareOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanAktarmaDashCompareOnGetMarkupMarjinResponse>> Handle(MizanAktarmaashCompareOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<MizanAktarmaDashCompareOnGetMarkupMarjinResponse>.Success(
                new MizanAktarmaDashCompareOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<DashBilancoViewMznShort>(), request.Request.options)),
                    InitialModel = request.InitialModel
                }));
        }

        var nRequestList = dashGelirTablosuManager.Get_MAINBilancoMznAktCompare(request.Request.compid,request.Request.nyear,request.Request.nmonth);
        request.InitialModel.nRequestList = nRequestList;
        
        return Task.FromResult(GenericResult<MizanAktarmaDashCompareOnGetMarkupMarjinResponse>.Success(
            new MizanAktarmaDashCompareOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(nRequestList.OrderBy(x => x.AccountMainID), request.Request.options)),
                InitialModel = request.InitialModel
            }));
    }
}