using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.upcheck;
public class upcheckOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}