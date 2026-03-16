using FinanceCheckUp.Domain.Common;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Models.Requests.ReportApis;

public class ReportGetListRequest : IUserIdAssignable , IRequest<GenericResult<ReportGetListResponse>>
{
    public DataSourceLoadOptions LoadOptions { get; set; }
    public string UserData { get; set; }
    public string UserId { get; set; }
}