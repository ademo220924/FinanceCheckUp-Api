using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Models.Requests.upaccounty;
public class UpaccountyOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}