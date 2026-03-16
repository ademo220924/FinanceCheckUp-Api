using FinanceCheckUp.Api.finansmanEntegrasyonWebService;
using FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationByUserIdPassword;
using FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinKaydet;
using FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinSil;
using FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinSilBank;
using FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationQnbByUserId;
using FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationUyumSoftByUserIdPassword;
using FinanceCheckUp.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/finansman-wsdl")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class FinansmanWsdlController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost]
    [Route("deneme")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DenemeAsync([FromBody] FinansmanEntegrasyonRequest finansmanEntegrasyonRequest)
    {

        var client = new FinansmanEntegrasyonWebServiceClient();


        // Kullanıcı adı ve parolayı ayarla
        string username = "fincheckup.entegrasyon";
        string password = "H6MjuGYu";


        // SOAP başlıklarına kullanıcı adı ve parolayı eklemek için EndpointBehavior ekle
        client.Endpoint.EndpointBehaviors.Add(new CustomHeaderBehavior(username, password));

        var response = await client.userValidationByUserIdPasswordAsync("23281778390", "123456", "112233");
        return Ok(response);
    }

    [HttpPost]
    [Route("qnb/userid")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ValidationByQnbUserIdRequestAsync([FromBody] FinansmanEntegrasyonRequest request, CancellationToken cancellationToken)
    {
        var command = new ValidationQnbByUserIdQuery { FinansmanEntegrasyonRequest = new FinansmanEntegrasyonRequest { FinansmanEntegrasyon = request.FinansmanEntegrasyon } };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("uyumsoft/userid-password")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ValidationUyumSoftByUserIdPasswordAsync([FromBody] FinansmanEntegrasyonRequest request, CancellationToken cancellationToken)
    {
        var command = new ValidationUyumSoftByUserIdPasswordQuery { FinansmanEntegrasyonRequest = new FinansmanEntegrasyonRequest { FinansmanEntegrasyon = request.FinansmanEntegrasyon } };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("userid-password")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ValidationByUserIdPasswordAsync([FromBody] FinansmanEntegrasyonRequest request, CancellationToken cancellationToken)
    {
        var command = new ValidationByUserIdPasswordQuery { FinansmanEntegrasyonRequest = new FinansmanEntegrasyonRequest { FinansmanEntegrasyon = request.FinansmanEntegrasyon } };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("defter-izin-sil")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ValidationDefterIzinSilAsync([FromBody] FinansmanEntegrasyonRequest request, CancellationToken cancellationToken)
    {
        var command = new ValidationDefterIzinSilQuery { FinansmanEntegrasyonRequest = new FinansmanEntegrasyonRequest { FinansmanEntegrasyon = request.FinansmanEntegrasyon } };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("defter-izin-sil-bank")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ValidationDefterIzinSilBankAsync([FromBody] FinansmanEntegrasyonRequest request, CancellationToken cancellationToken)
    {
        var command = new ValidationDefterIzinSilBankQuery { FinansmanEntegrasyonRequest = new FinansmanEntegrasyonRequest { FinansmanEntegrasyon = request.FinansmanEntegrasyon } };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("defter-izin-kaydet")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ValidationDefterIzinKaydetAsync([FromBody] FinansmanEntegrasyonRequest request, CancellationToken cancellationToken)
    {
        var command = new ValidationDefterIzinKaydetQuery { FinansmanEntegrasyonRequest = new FinansmanEntegrasyonRequest { FinansmanEntegrasyon = request.FinansmanEntegrasyon } };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}


