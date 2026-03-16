using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests;

public class BultenCreateRequest : IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
    public string SubTitle { get; set; }
    public string Kapsam { get; set; }
    public DateTime YururlulukTarih { get; set; }
    public string DuzenleyenKurum { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedUser { get; set; }
    public string Title { get; set; }
}