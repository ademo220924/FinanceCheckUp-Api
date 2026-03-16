using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.BrandedCancelUrl;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.BrandedSuccessUrl;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.CancelUrl;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PaySmart;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PaySmartNomb;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.PayWithQNBpay;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.Refund;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Command.SuccessUrl;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.CheckBinCode;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.Error;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetPaymentInfo;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetSmartPaymentInfo;
using FinanceCheckUp.Application.Features.BaseApp.Transactions.Query.GetSmartPaymentInfoNomb;
using FinanceCheckUp.Application.Models.Requests.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace FinanceCheckUp.Api.Controllers.v1;


[ApiVersion("1.0")]
[Route("api/transaction")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
public class TransactionController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


    [HttpPost("PaySmartNomb")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PaySmartNombAsync([FromBody] PaySmartNombRequest request, CancellationToken cancellationToken)
    {
        var command = new PaySmartNombCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost("PaySmart")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PaySmartAsync([FromBody] PaySmartRequest request, CancellationToken cancellationToken)
    {
        var command = new PaySmartCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("GetSmartPaymentInfoNomb")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSmartPaymentInfoNombAsync([FromBody] GetSmartPaymentInfoNombRequest request, CancellationToken cancellationToken)
    {
        var command = new GetSmartPaymentInfoNombQuery { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("PayWithQNBpay")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PayWithQNBpayAsync([FromBody] PayWithQNBpayRequest request, CancellationToken cancellationToken)
    {
        var command = new PayWithQNBpayCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("Refund")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> RefundAsync([FromBody] RefundRequest request, CancellationToken cancellationToken)
    {
        var command = new RefundCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("CheckBinCode")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CheckBinCodeAsync([FromBody] CheckBinCodeRequest request, CancellationToken cancellationToken)
    {
        var command = new CheckBinCodeQuery { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("SuccessUrl")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> SuccessUrlAsync([FromBody] SuccessUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new SuccessUrlCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


    [HttpPost("CancelUrl")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CancelUrlAsync([FromBody] CancelUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new CancelUrlCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("BrandedSuccessUrl")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> BrandedSuccessUrlAsync([FromBody] BrandedSuccessUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new BrandedSuccessUrlCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("BrandedCancelUrl")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> BrandedCancelUrlAsync([FromBody] BrandedCancelUrlRequest request, CancellationToken cancellationToken)
    {
        var command = new BrandedCancelUrlCommand { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("Error")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ErrorAsync([FromBody] ErrorRequest request, CancellationToken cancellationToken)
    {
        var command = new ErrorQuery { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("GetPaymentInfo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPaymentInfoAsync([FromBody] GetPaymentInfoRequest request, CancellationToken cancellationToken)
    {
        var command = new GetPaymentInfoQuery { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("GetSmartPaymentInfo")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetSmartPaymentInfoAsync([FromBody] GetSmartPaymentInfoRequest request, CancellationToken cancellationToken)
    {
        var command = new GetSmartPaymentInfoQuery { Model = request };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }


}