using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.GetHtml;

public class GetHtmlCommandHandler: IRequestHandler<GetHtmlCommand, GenericResult<GetHtmlResponse>>
{
    public Task<GenericResult<GetHtmlResponse>> Handle(GetHtmlCommand request, CancellationToken cancellationToken)
    {
        Bulten blt = new Bulten();//.Get_bulten(Convert.ToInt32(pageIndex));
        if (blt == null)
        {
            blt = new Bulten();//.Get_bulten(1);
        }
        return Json(blt);
    }
}
