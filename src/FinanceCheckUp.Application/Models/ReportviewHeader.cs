namespace FinanceCheckUp.Application.Models
{
    public class ReportviewHeader
    {
        //[TBLXMLSourceChk]    SP_TBLXMLSourceRepZone
        public int ID { get; set; }
        public float Amount { get; set; }
        public long CompanyID { get; set; }
        public float AmountBakiye { get; set; }
        public int Year { get; set; }
        public byte SubTypeID { get; set; }
        public byte MainTypeID { get; set; }

    }
}
