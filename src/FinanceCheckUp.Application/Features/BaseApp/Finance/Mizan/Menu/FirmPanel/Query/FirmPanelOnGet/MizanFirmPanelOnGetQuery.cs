using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.FirmPanel;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.FirmPanel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.FirmPanel.Query.FirmPanelOnGet
{
    public class MizanFirmPanelOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanFirmPanelOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanFirmPanelOnGetRequest Request { get; set; }
    }
}
