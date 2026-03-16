using FinanceCheckUp.Application.Models.Requests.Layouts;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutReport;

public class LayoutReportQuery:  IRequest<GenericResult<LayoutReportResponse>>,IUserIdAssignable
{
    public string UserId { get; set; }
}