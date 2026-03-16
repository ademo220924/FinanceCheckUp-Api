using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.ChangePassword;
public class ChangePasswordOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}