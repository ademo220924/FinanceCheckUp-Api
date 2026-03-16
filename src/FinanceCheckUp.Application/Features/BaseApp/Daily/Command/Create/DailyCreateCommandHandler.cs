using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Daily.Command.Create;

public class DailyCreateCommandHandle(IBultenManager bultenManager) : IRequestHandler<DailyCreateCommand, GenericResult<DailyCreateResponse>>
{
    public async Task<GenericResult<DailyCreateResponse>> Handle(DailyCreateCommand request, CancellationToken cancellationToken)
    {
        //asýl kod
        //var newEmployee = new Appointment();
        //JsonConvert.PopulateObject(values, newEmployee);

        //if (!TryValidateModel(newEmployee))
        //    return BadRequest(ModelState.IsValid);
        //newEmployee.Text = newEmployee.Description;
        //bulten.Save_Apintment(newEmployee);


        var appointment = new Appointment
        {
            AllDay = request.Model.AllDay,
            Description = request.Model.Description,
            EndDate = request.Model.EndDate,
            PriorityId = request.Model.PriorityId,
            StartDate = request.Model.StartDate,
            Status = request.Model.Status,
            Text = request.Model.Text
        };

        appointment.Id = bultenManager.Save_Apintment(appointment);

        return GenericResult<DailyCreateResponse>.Success(new DailyCreateResponse { Appointment = appointment });
    }
}