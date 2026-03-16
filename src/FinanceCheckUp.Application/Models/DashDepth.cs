namespace FinanceCheckUp.Application.Models
{
    public class DashDepth
    {
        public float KisaVadeBanka { get; set; }
        public float UzunVadeBanka { get; set; }
        public float KisaVadeMali { get; set; }
        public float UzunVadeMali { get; set; }
        public string DocumentMonthTr { get; set; }
        public int MainMonth { get; set; }
        public string MainMonthTx { get; set; }
        public string MainMonthTxa => MainMonth.ToString();
    }
}
