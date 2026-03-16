using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Delete;

public class DailyDeleteCommand : IRequest<GenericResult<DailyDeleteResponse>>
{
    public int Id { get; set; }
}