using DevExtreme.AspNet.Mvc;
using System.Text.Json.Serialization;

namespace fincheckup.ApiClients.Models.Requests.Daily;

public class DailyGetListRequest
{
    [JsonIgnore]
    public int Year { get; set; }
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }

}