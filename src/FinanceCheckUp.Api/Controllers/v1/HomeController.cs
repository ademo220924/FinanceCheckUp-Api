using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/home")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class HomeController : ControllerBase
{
}