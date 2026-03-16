using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests;

public class UserDeleteRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
    public long Id { get; set; }
}