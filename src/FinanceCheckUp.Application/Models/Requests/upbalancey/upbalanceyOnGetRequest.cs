using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Models.Requests.upbalancey;
public class UpbalanceyOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}