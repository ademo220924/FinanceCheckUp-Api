using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.upreportqnbtest;
public class upreportqnbtestOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}