using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital
{
    public class MizanDashWorkingCapitalOnGetRequest : IUserIdAssignable
    {
        [JsonIgnore] public  string UserId { get; set; }
    }
}
