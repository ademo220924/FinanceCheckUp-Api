using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.GetHtml;

public class GetHtmlCommandHandler(IBultenManager bultenManager): IRequestHandler<GetHtmlCommand, GenericResult<GetHtmlResponse>>
{
    public Task<GenericResult<GetHtmlResponse>> Handle(GetHtmlCommand request, CancellationToken cancellationToken)
    {

        var blt = bultenManager.Get_bulten(request.GetHtmlRequest.PageIndex);
        if (blt is not { Id: not 0 })
        {
            blt = new Bulten();
        }
        return Task.FromResult(GenericResult<GetHtmlResponse>.Success(new GetHtmlResponse() { ResultText = new JsonResult("ok"), Bulten = blt}));

    }
}
