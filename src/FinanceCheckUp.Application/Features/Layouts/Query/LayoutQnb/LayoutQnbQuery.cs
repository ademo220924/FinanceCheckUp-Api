using FinanceCheckUp.Application.Models.Requests.Layouts;
using FinanceCheckUp.Application.Models.Responses.Layouts;
using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.Layouts.Query.LayoutQnb;

public class LayoutQnbQuery:  IRequest<GenericResult<LayoutQnbResponse>>,IUserIdAssignable
{
    public string UserId { get; set; }
}