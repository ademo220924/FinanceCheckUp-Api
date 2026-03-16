using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Create;

public class DailyCreateCommand : IRequest<GenericResult<DailyCreateResponse>>
{
    public AppointmentRequest Model { get; set; }
}