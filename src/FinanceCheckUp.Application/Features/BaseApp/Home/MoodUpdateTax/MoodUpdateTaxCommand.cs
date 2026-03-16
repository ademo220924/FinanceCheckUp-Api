using FinanceCheckUp.Application.Models.Requests.Home;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateTax;

public class MoodUpdateTaxCommand: IRequest<GenericResult<MoodUpdateTaxResponse>>
{
    public MoodUpdateTaxRequest MoodUpdateTaxRequest { get; set; }
}
