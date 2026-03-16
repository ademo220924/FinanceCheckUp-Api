using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests;

public class DailyUpdateRequest
{
    public int Id { get; set; }
    public AppointmentRequest Model { get; set; }
}