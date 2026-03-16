using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Models.Requests.upbalance;
public class UpbalanceOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}