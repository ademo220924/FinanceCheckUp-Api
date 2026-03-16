namespace FinanceCheckUp.Application.Models.ViewModel.Reports
{
    public class CashflowView
    {
        public float TypeID { get; set; }
        public long CompanyID { get; set; }
        public float Amount { get; set; }
        public string MainDesc { get; set; }
        public int Year { get; set; }
    }

    //PR.OrderRequestsMainID  ,ord.ItemName,ord.EstimatedCost ,ord.VendorID,ord.QuantityChecked,SUM(ord.QuantityChecked*ord.EstimatedCost) as Total




}
