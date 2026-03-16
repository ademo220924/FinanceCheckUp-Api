using FinanceCheckUp.Application.Managers.SqlQueryManager;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers;

[ExcludeFromCodeCoverage]
[ApiVersion("1.0")]
[Route("api/common")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class CommonController(IUserManager userManager) : ControllerBase
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public IActionResult Status()
    {
        var appUser = userManager.GetPasswordwithAppUser("erhan.arguc@gmail.com");
        return Ok(appUser);
    }
}