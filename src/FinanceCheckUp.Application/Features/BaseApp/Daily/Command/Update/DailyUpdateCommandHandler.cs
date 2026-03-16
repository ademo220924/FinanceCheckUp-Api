using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Update;

public class DailyUpdateCommandHandle(IAppointmentRepository appoitmentRepository, IBultenManager bultenManager) : IRequestHandler<DailyUpdateCommand, GenericResult<DailyUpdateResponse>>
{
    public async Task<GenericResult<DailyUpdateResponse>> Handle(DailyUpdateCommand request, CancellationToken cancellationToken)
    {
        var model = await appoitmentRepository.GetByIdAsync(request.Id.ToString(), cancellationToken);
        if (model == null)
            throw new NotFoundException(nameof(Appointment), request.Id.ToString());

        model.AllDay = request.Values.AllDay;
        model.Description = request.Values.Description;
        model.EndDate = request.Values.EndDate;
        model.PriorityId = request.Values.PriorityId;
        model.StartDate = request.Values.StartDate;
        model.Status = request.Values.Status;
        model.Text = request.Values.Text;
        model.Id = request.Id;

        bultenManager.UpdateApintment(model);

        return GenericResult<DailyUpdateResponse>.Success(new DailyUpdateResponse { Appointment = model });
    }
}