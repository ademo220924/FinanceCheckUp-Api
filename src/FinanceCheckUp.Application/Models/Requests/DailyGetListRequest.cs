using DevExtreme.AspNet.Mvc;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests;

public class DailyGetListRequest
{
    [JsonIgnore]
    public int Year { get; set; }
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }

}