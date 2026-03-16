namespace FinanceCheckUp.Application.Models.ViewModel.Reports
{

    public class OrderReportFilterView
    {
        public OrderReportFilterView()
        {

            FirstDate = DateTime.Now;
            LastDate = DateTime.Now;
        }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public DateTime FirstDate { get; set; }
        public int VendorID { get; set; }
        public DateTime LastDate { get; set; }
    }
}
