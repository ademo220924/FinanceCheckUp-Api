using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.upcmconsole;
public class upcmconsoleOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}