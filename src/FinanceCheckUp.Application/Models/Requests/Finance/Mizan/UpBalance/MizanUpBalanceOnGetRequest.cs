using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance
{
    public class MizanUpBalanceOnGetRequest : IUserIdAssignable
    {
        [JsonIgnore] public  string UserId { get; set; }
    }
}
