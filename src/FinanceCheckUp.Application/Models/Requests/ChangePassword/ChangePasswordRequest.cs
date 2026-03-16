using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.ChangePassword;
public class ChangePasswordRequest
{

    public long? UserID { get; set; }
    public HhvnUsers? CurrentUser { get; set; }
    public IEnumerable<Company>? mreqListCompany { get; set; }
    public List<UserType>? mreqListUserType { get; set; }
    public IEnumerable<City>? mreqListCity { get; set; }
    public IEnumerable<YearResult>? myearResult { get; set; }
    public HhvnUsers? mrequest { get; set; }
    public string? mreqListCitystr { get; set; }
}