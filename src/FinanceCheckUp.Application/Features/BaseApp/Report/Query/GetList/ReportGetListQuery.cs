using FinanceCheckUp.Application.Models.Requests.ReportApis;
using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Report.Query.GetList;

public class ReportGetListQuery : IRequest<GenericResult<ReportGetListResponse>>
{
    public ReportGetListRequest Request { get; set; }
}