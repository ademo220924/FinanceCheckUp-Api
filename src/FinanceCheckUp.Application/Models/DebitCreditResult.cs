namespace FinanceCheckUp.Application.Models
{
    public class DebitCreditResult
    {
        public string MVal { get; set; }
        public string MText { get; set; }

        public static IEnumerable<DebitCreditResult> getValue()
        {
            List<DebitCreditResult> nresult = new List<DebitCreditResult>();


            DebitCreditResult nval = new DebitCreditResult();
            nval.MVal = "D";
            nval.MText = "Debit";
            nresult.Add(nval);
            nval = new DebitCreditResult();
            nval.MVal = "C";
            nval.MText = "Credit";
            nresult.Add(nval);
            return nresult;
        }
    }
}
