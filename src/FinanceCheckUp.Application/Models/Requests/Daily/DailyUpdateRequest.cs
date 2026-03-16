namespace fincheckup.ApiClients.Models.Requests.Daily;

public class DailyUpdateRequest
{
    public int Id { get; set; }
    public AppointmentRequest Model { get; set; }
}