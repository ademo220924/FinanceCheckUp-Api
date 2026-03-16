namespace FinanceCheckUp.Application.Models
{
    public class SourceResult
    {
        public int MYear { get; set; }
        public string MText { get; set; }
        public static IEnumerable<SourceResult> getValue()
        {
            List<SourceResult> nresult = new List<SourceResult>();


            SourceResult nval = new SourceResult();
            nval.MYear = 0;
            nval.MText = "Bilgisayarımdan";
            nresult.Add(nval);

            nval = new SourceResult();
            nval.MYear = 1;
            nval.MText = "Qnb E-Finans";
            nresult.Add(nval);
            //nval = new SourceResult();
            //nval.MYear = 2;
            //nval.MText = "Mikro-Zirve";
            //nresult.Add(nval);

            nval = new SourceResult();
            nval.MYear = 3;
            nval.MText = "Uyumsoft";
            nresult.Add(nval);
            return nresult.OrderBy(x => x.MYear);
        }
        public static IEnumerable<SourceResult> getValueNom()
        {
            List<SourceResult> nresult = new List<SourceResult>();


            SourceResult nval = new SourceResult();
            nval.MYear = 0;
            nval.MText = "Bilgisayarımdan";
            nresult.Add(nval);

            SourceResult nval1 = new SourceResult();
            nval1.MYear = 4;
            nval1.MText = "Mikro-Zirve";
            nresult.Add(nval1);
            return nresult.OrderBy(x => x.MYear);
        }
    }
}
