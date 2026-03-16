using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Update;

public class DailyUpdateCommand : IRequest<GenericResult<DailyUpdateResponse>>
{
    public int Id { get; set; }
    public AppointmentRequest Values { get; set; }
}