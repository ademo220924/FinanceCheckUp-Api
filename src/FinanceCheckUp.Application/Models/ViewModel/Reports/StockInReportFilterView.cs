namespace FinanceCheckUp.Application.Models.ViewModel.Reports
{
    public class StockInReportFilterView
    {
        public StockInReportFilterView()
        {

            FirstDate = DateTime.Now;
            LastDate = DateTime.Now;
        }

        public int VendorID { get; set; }
        public DateTime FirstDate { get; set; }

        public DateTime LastDate { get; set; }
    }

    //PR.OrderRequestsMainID  ,ord.ItemName,ord.EstimatedCost ,ord.VendorID,ord.QuantityChecked,SUM(ord.QuantityChecked*ord.EstimatedCost) as Total




}
