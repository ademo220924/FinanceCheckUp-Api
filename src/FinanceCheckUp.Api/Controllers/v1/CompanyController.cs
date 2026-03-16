using FinanceCheckUp.Application.Features.BaseApp.Company.Command.Create;
using FinanceCheckUp.Application.Features.BaseApp.Company.Command.Update;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/company")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class CompanyController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    /// <summary>
    /// //public JsonResult FormSubmitCompany(Companies model)
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CompanyCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyCreateCommand { CompanyCreateRequest = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    /// <summary>
    /// //public JsonResult FormSubmitCompany(Companies model)
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateAsync([FromBody] CompanyUpdateRequest request, CancellationToken cancellationToken)
    {
        var command = new CompanyUpdateCommand { CompanyUpdateRequest = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}