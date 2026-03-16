namespace FinanceCheckUp.Application.Models
{
    public class DashYearlyResultChartCRM
    {
        public DashYearlyResultChartCRM()
        {
            nresult = new List<DashYearlyResultCRM>();
        }
        public List<DashYearlyResultCRM> nresult { get; set; }

        public void SetResult(List<DashYearlyResultCRMMain> tdash, int nyear)
        {
            if (tdash == null)
            {
                return;
            }

            DashYearlyResultCRM nv = new DashYearlyResultCRM();
            //List<DashYearlyResultTx> nlist = DashYearlyResultTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyResultCRM();
                nv.Description = item.Description;
                nv.Year = item.Year;
                nv.SortVal = 1;
                nv.ValueType = "Debit";
                nv.Value = item.Debit;
                nresult.Add(nv);

                nv = new DashYearlyResultCRM();
                nv.Description = item.Description;
                nv.Year = item.Year;
                nv.SortVal = 2;
                nv.ValueType = "Credit";
                nv.Value = item.Credit;
                nresult.Add(nv);


            }


        }
        public void SetResultA(List<DashYearlyResultCRMMain> tdash, int nyear)
        {
            if (tdash == null)
            {
                return;
            }

            DashYearlyResultCRM nv = new DashYearlyResultCRM();
            //List<DashYearlyResultTx> nlist = DashYearlyResultTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyResultCRM();
                nv.Description = item.Description;
                nv.Year = item.Year;
                nv.SortVal = 1;
                nv.ValueType = "Debit";
                nv.Value = item.Debit;
                nresult.Add(nv);



            }


        }
        public static List<DashYearlyResultMain> SetResultMain(DashYearlyResultWorkingCapital tdash, int nyearr)
        {
            if (tdash == null)
            {
                return new List<DashYearlyResultMain>();
            }

            DashYearlyResultMain nv = new DashYearlyResultMain();
            List<DashYearlyResultMain> nreesult1 = new List<DashYearlyResultMain>();

            string txyear = nyearr.ToString();

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/01/15");
            nv.SortVal = 1;
            nv.Value = tdash.January;
            nv.DocumentMonthTr = "Ocak";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/02/15");
            nv.SortVal = 2;
            nv.Value = tdash.February;
            nv.DocumentMonthTr = "Şubat";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/03/15");
            nv.SortVal = 3;
            nv.Value = tdash.March;
            nv.DocumentMonthTr = "Mart";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/04/15");
            nv.SortVal = 4;
            nv.Value = tdash.April;
            nv.DocumentMonthTr = "Nisan";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/05/15");
            nv.SortVal = 5;
            nv.Value = tdash.May;
            nv.DocumentMonthTr = "Mayıs";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/06/15");
            nv.SortVal = 6;
            nv.Value = tdash.June;
            nv.DocumentMonthTr = "Haziran";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/07/15");
            nv.SortVal = 7;
            nv.Value = tdash.July;
            nv.DocumentMonthTr = "Temmuz";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/08/15");
            nv.SortVal = 8;
            nv.Value = tdash.August;
            nv.DocumentMonthTr = "Ağustos";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/09/15");
            nv.SortVal = 9;
            nv.Value = tdash.September;
            nv.DocumentMonthTr = "Eylül";
            nreesult1.Add(nv);

            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/10/15");
            nv.SortVal = 10;
            nv.Value = tdash.October;
            nv.DocumentMonthTr = "Ekim";
            nreesult1.Add(nv);
            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/11/15");
            nv.SortVal = 11;
            nv.Value = tdash.November;
            nv.DocumentMonthTr = "Kasım";
            nreesult1.Add(nv);
            nv = new DashYearlyResultMain();
            nv.Month = DateTime.Parse(txyear + "/12/15");
            nv.SortVal = 12;
            nv.DocumentMonthTr = "Aralık";
            nv.Value = tdash.December;
            nreesult1.Add(nv);



            return nreesult1;
        }
    }
}
