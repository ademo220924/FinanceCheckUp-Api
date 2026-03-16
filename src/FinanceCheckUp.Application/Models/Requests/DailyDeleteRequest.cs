using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests;

public class DailyDeleteRequest
{
    [JsonIgnore]
    public int Id { get; set; }
}