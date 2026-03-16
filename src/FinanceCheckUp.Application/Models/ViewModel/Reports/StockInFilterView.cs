namespace FinanceCheckUp.Application.Models.ViewModel.Reports
{
    public class StockInFilterView
    {
        public int OrderRequestID { get; set; }
        public int VendorID { get; set; }
        public string SearchValue { get; set; }
    }

    //PR.OrderRequestsMainID  ,ord.ItemName,ord.EstimatedCost ,ord.VendorID,ord.QuantityChecked,SUM(ord.QuantityChecked*ord.EstimatedCost) as Total




}
