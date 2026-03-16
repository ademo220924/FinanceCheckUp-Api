namespace FinanceCheckUp.Application.Models
{
    public class ReportDashViewWCap
    {

        public static DashRep getRealyVal(IEnumerable<YearlyReportDash> xSetter)
        {
            DashRep ndash = new DashRep();
            int lastNum = 1;
            if (xSetter.Where(x => x.TotalGelir != 0).Count() > 0)
            {
                lastNum = xSetter.Where(x => x.TotalGelir != 0).Max(x => x.MainMonth);
            }

            ndash.EntryCountTotal = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountLast = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth == lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountBefore = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth != lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            return ndash;
        }
        public static List<DashDepth> getRealyValDashDepth(IEnumerable<YearlyReportDash> xSetter)
        {
            List<DashDepth> ndash = new List<DashDepth>();
            DashDepth ndash1 = new DashDepth();
            var nlist1 = xSetter.Where(x => x.TypeZone == 1);
            var nlist3 = xSetter.Where(x => x.TypeZone == 3);
            var nlist5 = xSetter.Where(x => x.TypeZone == 5);
            var nlist7 = xSetter.Where(x => x.TypeZone == 7);

            for (int i = 1; i < 13; i++)
            {
                ndash1 = new DashDepth();
                ndash1.MainMonth = i;
                ndash1.KisaVadeBanka = nlist1.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.UzunVadeBanka = nlist3.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.KisaVadeMali = nlist5.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.UzunVadeMali = nlist7.Where(x => x.MainMonth == i).Select(x => x.TotalGelir).FirstOrDefault();
                ndash1.DocumentMonthTr = nlist1.Where(x => x.MainMonth == i).Select(x => x.DocumentMonthTr).FirstOrDefault();
                ndash.Add(ndash1);

            }

            return ndash;
        }
        public static List<DashDepth> getRealyValDashDepthMizan(IEnumerable<YearlyReportDash> xSetter)
        {
            List<DashDepth> ndash = new List<DashDepth>();
            DashDepth ndash1 = new DashDepth();
            var nlist1 = xSetter.Where(x => x.TypeZone == 1);
            var nlist3 = xSetter.Where(x => x.TypeZone == 3);
            var nlist5 = xSetter.Where(x => x.TypeZone == 5);
            var nlist7 = xSetter.Where(x => x.TypeZone == 7);

            List<int> nlist = xSetter.Select(x => x.MainYear).Distinct().ToList();

            for (int i = 0; i < nlist.Count(); i++)
            {
                ndash1 = new DashDepth();
                ndash1.MainMonth = nlist[i];
                ndash1.KisaVadeBanka = nlist1.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash1.UzunVadeBanka = nlist3.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash1.KisaVadeMali = nlist5.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash1.UzunVadeMali = nlist7.Where(x => x.MainYear == nlist[i]).Select(x => x.Amount).FirstOrDefault();
                ndash.Add(ndash1);

            }

            return ndash;
        }
        public static DashRep getRealyValT(IEnumerable<DashYearlyResultMain> xSetter)
        {
            DashRep ndash = new DashRep();
            int lastNum = 1;
            if (xSetter.Where(x => x.Value != 0).Count() > 0)
            {
                lastNum = xSetter.Where(x => x.Value != 0).Max(x => x.SortVal);
            }

            ndash.EntryCountTotal = xSetter.Sum(x => x.Value) != 0 ? xSetter.Where(x => x.SortVal == lastNum).Select(x => x.Value).FirstOrDefault().ToString("N0") : "1";
            if (lastNum > 1)
            {
                ndash.EntryCountLast = xSetter.Sum(x => x.Value) != 0 ? xSetter.Where(x => (lastNum != 1) && x.SortVal == lastNum - 1).Select(x => x.Value).FirstOrDefault().ToString("N0") : "1";
            }
            else
            {
                ndash.EntryCountLast = ndash.EntryCountTotal;
            }

            if (lastNum > 2)
            {
                ndash.EntryCountBefore = xSetter.Sum(x => x.Value) != 0 ? xSetter.Where(x => (lastNum != 2) && x.SortVal == lastNum - 2).Select(x => x.Value).FirstOrDefault().ToString("N0") : "1";
            }
            else
            {
                ndash.EntryCountBefore = ndash.EntryCountLast;
            }

            return ndash;
        }
        public static DashRep getRealyValGraphic(IEnumerable<YearlyReportDashGraphic> xSetter)
        {
            DashRep ndash = new DashRep();
            int lastNum = 1;
            if (xSetter.Where(x => x.TotalGelir != 0).Count() > 0)
            {
                lastNum = xSetter.Where(x => x.TotalGelir != 0).Max(x => x.MainMonth);
            }

            ndash.EntryCountTotal = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountLast = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth == lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            ndash.EntryCountBefore = xSetter.Sum(x => x.TotalGelir) != 0 ? xSetter.Where(x => x.MainMonth != lastNum).Sum(x => x.TotalGelir).ToString("N0") : "1";
            return ndash;
        }

    }

}
