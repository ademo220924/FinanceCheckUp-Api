using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;
namespace FinanceCheckUp.Application.Models.Requests.Upload;
public class UploadOnGetRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}