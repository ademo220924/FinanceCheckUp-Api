using Microsoft.AspNetCore.Http;

namespace FinanceCheckUp.Application.Models.Common;

public class XMlook
{
    public int id { get; set; }
    public string ide { get; set; }
    public string idexml { get; set; }
    public List<IFormFile> file { get; set; } = [];
    public string Caption { get; set; }
}