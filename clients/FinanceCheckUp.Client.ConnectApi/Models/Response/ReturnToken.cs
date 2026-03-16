using Newtonsoft.Json;

namespace FinanceCheckUp.Client.ConnectApi.Models.Response;

public class ReturnToken
{
    [JsonProperty(PropertyName = "success")] public long success { get; set; }
    [JsonProperty(PropertyName = "responseMessage")] public string responseMessage { get; set; }
}