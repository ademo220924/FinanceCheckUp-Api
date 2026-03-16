namespace FinanceCheckUp.Application.Models
{
    public class AppLogs
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int LogTypeID { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public String Detail { get; set; }
    }
}
