namespace FinanceCheckUp.Application.Models.ViewModel.Reports
{
    public class ReportFilterView
    {
        public ReportFilterView()
        {
            FirstDate = DateTime.Now;

        }
        public long CompanyID { get; set; }
        public string SearchValue { get; set; }
        public DateTime FirstDate { get; set; }
    }

    //PR.OrderRequestsMainID  ,ord.ItemName,ord.EstimatedCost ,ord.VendorID,ord.QuantityChecked,SUM(ord.QuantityChecked*ord.EstimatedCost) as Total




}
