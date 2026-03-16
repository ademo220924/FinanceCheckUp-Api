using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Models.Requests.upchecky;
public class UpcheckyOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}