using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.GetHtml;

public class GetHtmlCommand: IRequest<GenericResult<GetHtmlResponse>>
{
    public GetHtmlRequest GetHtmlRequest { get; set; }
}
