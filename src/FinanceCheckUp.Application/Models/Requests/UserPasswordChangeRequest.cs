using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests;

public class UserPasswordChangeRequest : IUserIdAssignable
{
    public int Id { get; set; }
    public string Password { get; set; }

    [JsonIgnore] public  string UserId { get; set; }
}