using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.dashbilancorvnmlt;
public class DashbilancorvnmltOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}