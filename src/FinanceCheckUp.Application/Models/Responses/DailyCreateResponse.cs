using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Responses;

public class DailyCreateResponse
{
    public Appointment Appointment { get; set; }
}