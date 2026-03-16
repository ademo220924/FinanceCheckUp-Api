using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.DashBilanco;
public class DashBilancoOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}