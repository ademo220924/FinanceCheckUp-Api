namespace FinanceCheckUp.Application.Models
{
    public class YearResult
    {
        public int MYear { get; set; }
        public string MText { get; set; }

        public static IEnumerable<YearResult> getValue()
        {
            List<YearResult> nresult = new List<YearResult>();
            int fyear = DateTime.Now.AddYears(-5).Year;
            int lyear = DateTime.Now.Year;
            for (int i = fyear; i <= lyear; i++)
            {
                YearResult nval = new YearResult();
                nval.MYear = i;
                nval.MText = i.ToString();
                nresult.Add(nval);
            }
            return nresult.OrderBy(x => x.MYear);
        }

        public static IEnumerable<YearResult> getValuemonth()
        {
            List<YearResult> nresult = new List<YearResult>();

            for (int i = 1; i <= 12; i++)
            {
                YearResult nval = new YearResult();
                nval.MYear = i;
                nval.MText = i.ToString();
                nresult.Add(nval);
            }
            return nresult.OrderBy(x => x.MYear);
        }
    }
}
