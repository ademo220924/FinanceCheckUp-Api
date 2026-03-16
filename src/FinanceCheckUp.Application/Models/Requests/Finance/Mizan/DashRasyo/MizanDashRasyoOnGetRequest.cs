using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo
{
    public class MizanDashRasyoOnGetRequest : IUserIdAssignable
    {
        [JsonIgnore] public  string UserId { get; set; }
        
    }
}
