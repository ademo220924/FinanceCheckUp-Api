using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.ReportApis;
using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Newtonsoft.Json;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetList;

public class ReportGetListQueryHandle(IDataManager dataManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<ReportGetListRequest, GenericResult<ReportGetListResponse>>
{
    ReportFilterView nReportFilterView = new ReportFilterView();
    IEnumerable<DataViewer> nlist;
    DataViewerMain mrequestDataViewer;

    public async Task<GenericResult<ReportGetListResponse>> Handle(ReportGetListRequest request, CancellationToken cancellationToken)
    {
        mrequestDataViewer = new DataViewerMain();
        var md = JsonConvert.DeserializeObject<ReportFilterView>(request.UserData);

        if (md.CompanyID == 0)
        {
            nlist = dataManager.Get_AllbyCsvIDEntryNoNope();
        }
        else
        {
            int _csvid = tBLXmlManager.GetComapnyIDByMonth(md.CompanyID, md.FirstDate.Month, md.FirstDate.Year);
            nlist = dataManager.Get_AllbyCsvIDEntryNo(_csvid, md.SearchValue);
        }

        mrequestDataViewer.SetDataViewer(nlist.ToList());

        return GenericResult<ReportGetListResponse>.Success(new ReportGetListResponse() { EntryData = mrequestDataViewer.EntryData });

    }
}