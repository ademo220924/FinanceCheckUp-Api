using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests;

public class UserCompanyUpdateRequest : IUserIdAssignable
{
    public int Id { get; set; }
    public string OperationUserId { get; set; }
    public List<long> CompanyList { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}