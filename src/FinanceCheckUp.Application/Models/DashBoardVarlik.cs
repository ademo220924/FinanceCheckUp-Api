namespace FinanceCheckUp.Application.Models
{
    public class DashBoardVarlik
    {

        public long Donen { get; set; }
        public long Duran { get; set; }
        public long CompanyID { get; set; }
        public DateTime Datum { get; set; }
        public long total => Donen + Duran;

        public string datetext => Datum.ToString("yyyy-MM");

    }
}
