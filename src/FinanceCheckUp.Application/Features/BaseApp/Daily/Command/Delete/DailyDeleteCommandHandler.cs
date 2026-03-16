using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Delete;

public class DailyDeleteCommandHandle(IAppointmentRepository  appoitmentRepository) : IRequestHandler<DailyDeleteCommand, GenericResult<DailyDeleteResponse>>
{
    public async Task<GenericResult<DailyDeleteResponse>> Handle(DailyDeleteCommand request, CancellationToken cancellationToken)
    {
        //bulten.DELETEApintment(key);

        var model = await appoitmentRepository.GetByIdAsync(request.Id.ToString(), cancellationToken);
        if (model == null)
            throw new NotFoundException(nameof(Appointment), request.Id.ToString());

        var deleted = await appoitmentRepository.DeleteAsync(request.Id.ToString(), cancellationToken);
        if (!deleted)
            throw new DeleteOperationException(nameof(Appointment), request.Id.ToString());

        return GenericResult<DailyDeleteResponse>.Success(new DailyDeleteResponse() { });
    }
}