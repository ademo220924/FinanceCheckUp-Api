using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Responses;

public class DailyUpdateResponse
{
    public Appointment Appointment { get; set; }
}