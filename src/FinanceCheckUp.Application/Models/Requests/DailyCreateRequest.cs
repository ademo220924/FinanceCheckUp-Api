using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests;

public class DailyCreateRequest
{
    public AppointmentRequest Model { get; set; }
}