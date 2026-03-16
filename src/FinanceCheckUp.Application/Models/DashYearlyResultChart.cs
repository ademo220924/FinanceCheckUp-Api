namespace FinanceCheckUp.Application.Models
{
    public class DashYearlyResultChart
    {
        public DashYearlyResultChart()
        {
            nresult = new List<DashYearlyResultMain>();
        }
        public List<DashYearlyResultMain> nresult { get; set; }

        public void SetResult(List<DashYearlyResult> tdash, int nyear)
        {
            if (tdash == null)
            {
                return;
            }

            DashYearlyResultMain nv = new DashYearlyResultMain();
            //List<DashYearlyResultTx> nlist = DashYearlyResultTx.setDashBilanco(tdash);

            string txyear = nyear.ToString();
            foreach (var item in tdash)
            {
                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/01/15");
                nv.SortVal = 1;
                nv.Value = item.January;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/02/15");
                nv.SortVal = 2;
                nv.Value = item.February;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/03/15");
                nv.SortVal = 3;
                nv.Value = item.March;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/04/15");
                nv.SortVal = 4;
                nv.Value = item.April;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/05/15");
                nv.SortVal = 5;
                nv.Value = item.May;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/06/15");
                nv.SortVal = 6;
                nv.Value = item.June;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/07/15");
                nv.SortVal = 7;
                nv.Value = item.July;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/08/15");
                nv.SortVal = 8;
                nv.Value = item.August;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/09/15");
                nv.SortVal = 9;
                nv.Value = item.September;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);

                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/10/15");
                nv.SortVal = 10;
                nv.Value = item.October;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);
                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/11/15");
                nv.SortVal = 11;
                nv.Value = item.November;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);
                nv = new DashYearlyResultMain();
                nv.Description = item.Description;
                nv.Month = DateTime.Parse(txyear + "/12/15");
                nv.SortVal = 12;
                nv.Value = item.December;
                nv.TypeID = item.TypeID;
                nresult.Add(nv);
                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Ocak"; Date = DateTime.Parse("2013/01/06")
                //nv.SortVal = 1;
                //nv.Value = item.January;

                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Şubat";
                //nv.SortVal = 2;
                //nv.Value = item.February;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Mart";
                //nv.SortVal = 3;
                //nv.Value = item.March;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Nisan";
                //nv.SortVal = 4;
                //nv.Value = item.April;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Mayıs";
                //nv.SortVal = 5;
                //nv.Value = item.May;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Haziran";
                //nv.SortVal = 6;
                //nv.Value = item.June;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Temmuz"; 
                // nv.SortVal = 7;
                //nv.Value = item.July;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Ağustos";
                //nv.SortVal = 8;
                //nv.Value = item.August;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Eylül";
                //nv.SortVal = 9;
                //nv.Value = item.September;
                //nresult.Add(nv);

                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Ekim";
                //nv.SortVal = 10;
                //nv.Value = item.October;
                //nresult.Add(nv);
                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Kasım";
                //nv.SortVal = 11;
                //nv.Value = item.November;
                //nresult.Add(nv);
                //nv = new DashYearlyResultMain();
                //nv.Description = item.Description;
                //nv.Month = "Aralık";
                //nv.SortVal = 12;
                //nv.Value = item.December;
                //nresult.Add(nv);
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
