namespace FinanceCheckUp.Application.Models
{
    public class StockHistoryView
    {
        public int StockHistoryID { get; set; }
        public int Piece { get; set; }
        public string InStoreName { get; set; }
        public string OutStoreName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
