namespace FinanceCheckUp.Application.Models
{
    public class ErrorCheckSet
    {
        public int ID { get; set; }
        public string MainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public string InMainDesc { get; set; }
        public string InMainDescDC { get; set; }
        public string OutMainDesc { get; set; }
        public string OutMainDescDC { get; set; }
        public float CheckAmount { get; set; }
        public int QueryType { get; set; }
    }
}
