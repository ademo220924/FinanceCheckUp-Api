using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Models.Requests.upreportmainy;
public class UpreportmainyOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}