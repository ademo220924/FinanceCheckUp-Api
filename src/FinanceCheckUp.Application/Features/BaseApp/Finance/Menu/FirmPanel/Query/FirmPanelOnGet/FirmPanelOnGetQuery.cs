using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Menu.FirmPanel;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.FirmPanel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.FirmPanel.Query.FirmPanelOnGet
{
    public class FirmPanelOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FirmPanelOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public FirmPanelOnGetRequest Request { get; set; }
    }
}
