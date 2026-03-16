using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.upreportqnb;
public class upreportqnbOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }

}