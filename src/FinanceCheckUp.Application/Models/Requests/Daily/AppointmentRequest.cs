using System;

namespace fincheckup.ApiClients.Models.Requests.Daily;

public class AppointmentRequest
{
    public int AppointmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Text { get; set; }
    public string Description { get; set; }
    public bool AllDay { get; set; }
    public byte? PriorityId { get; set; }
    public byte Status { get; set; }
}