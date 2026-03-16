using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Diagnostics;

namespace FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.Error;

public class ErrorQueryHandler : IRequestHandler<ErrorQuery, GenericResult<ErrorViewModel>>
{
    public async Task<GenericResult<ErrorViewModel>> Handle(ErrorQuery request, CancellationToken cancellationToken)
    {
        return GenericResult<ErrorViewModel>.Success(new ErrorViewModel { RequestId = Activity.Current.Id });
        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}