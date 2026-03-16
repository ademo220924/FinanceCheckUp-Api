using System.Text.Json.Serialization;

namespace fincheckup.ApiClients.Models.Requests.Daily;

public class DailyDeleteRequest
{
    [JsonIgnore]
    public int Id { get; set; }
}