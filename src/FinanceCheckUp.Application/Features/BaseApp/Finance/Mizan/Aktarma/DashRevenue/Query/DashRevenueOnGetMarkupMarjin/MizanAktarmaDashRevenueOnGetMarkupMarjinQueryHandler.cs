using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashRevenue;
using FinanceCheckUp.Application.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Aktarma.DashRevenue.Query.DashRevenueOnGetMarkupMarjin;

public class MizanAktarmaDashRevenueOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanAktarmaDashRevenueOnGetMarkupMarjinQuery, GenericResult<MizanAktarmaDashRevenueOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanAktarmaDashRevenueOnGetMarkupMarjinResponse>> Handle(MizanAktarmaDashRevenueOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<MizanAktarmaDashRevenueOnGetMarkupMarjinResponse>.Success(
                new MizanAktarmaDashRevenueOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<DashBilancoViewMznShort>(), request.Request.options)),
                    InitialModel = request.InitialModel
                }));
        }

        var nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMulti(request.Request.compid);
        request.InitialModel.nRequestList = nRequestList;
        
        return Task.FromResult(GenericResult<MizanAktarmaDashRevenueOnGetMarkupMarjinResponse>.Success(
            new MizanAktarmaDashRevenueOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.options)),
                InitialModel = request.InitialModel
            }));
        
        
        
    }
}

