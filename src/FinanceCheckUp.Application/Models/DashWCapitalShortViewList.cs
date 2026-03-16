using System.Globalization;

namespace FinanceCheckUp.Application.Models
{
    public class DashWCapitalShortViewList
    {
        public static List<DashWCapitalShortView> getListDashWC(DashBilancoView coord)
        {
            List<DashWCapitalShortView> nlist = new List<DashWCapitalShortView>();
            DashWCapitalShortView nvWC = new DashWCapitalShortView();

            if (coord.January != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Ocak Ayı(W/C)"; nvWC.mValue = coord.January.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.February != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Şubat Ayı(W/C)"; nvWC.mValue = coord.February.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.March != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Mart Ayı(W/C)"; nvWC.mValue = coord.March.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.April != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Nisan Ayı(W/C)"; nvWC.mValue = coord.April.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.May != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Mayıs Ayı(W/C)"; nvWC.mValue = coord.May.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.June != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Haziran Ayı(W/C)"; nvWC.mValue = coord.June.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.July != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Temmuz Ayı(W/C)"; nvWC.mValue = coord.July.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.August != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Ağustos Ayı(W/C)"; nvWC.mValue = coord.August.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.September != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Eylül Ayı(W/C)"; nvWC.mValue = coord.September.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.October != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Ekim Ayı(W/C)"; nvWC.mValue = coord.October.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.November != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Kasım Ayı(W/C)"; nvWC.mValue = coord.November.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            if (coord.December != 0) { nvWC = new DashWCapitalShortView(); nvWC.mText = "Aralık Ayı(W/C)"; nvWC.mValue = coord.December.ToString("N0", new CultureInfo("de-DE")); nlist.Add(nvWC); }
            return nlist;
        }
        public static List<DashWCapitalShortViewChart> getListDashWChart(DashBilancoView coord)
        {
            List<DashWCapitalShortViewChart> nlist = new List<DashWCapitalShortViewChart>();
            DashWCapitalShortViewChart nvWC = new DashWCapitalShortViewChart();

            if (coord.January != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Ocak"; nvWC.mValue = Convert.ToInt32(coord.January); nlist.Add(nvWC); }
            if (coord.February != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Şubat"; nvWC.mValue = Convert.ToInt32(coord.February); nlist.Add(nvWC); }
            if (coord.March != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Mart"; nvWC.mValue = Convert.ToInt32(coord.March); nlist.Add(nvWC); }
            if (coord.April != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Nisan"; nvWC.mValue = Convert.ToInt32(coord.April); nlist.Add(nvWC); }
            if (coord.May != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Mayıs"; nvWC.mValue = Convert.ToInt32(coord.May); nlist.Add(nvWC); }
            if (coord.June != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Haziran"; nvWC.mValue = Convert.ToInt32(coord.June); nlist.Add(nvWC); }
            if (coord.July != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Temmuz"; nvWC.mValue = Convert.ToInt32(coord.July); nlist.Add(nvWC); }
            if (coord.August != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Ağustos"; nvWC.mValue = Convert.ToInt32(coord.August); nlist.Add(nvWC); }
            if (coord.September != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Eylül"; nvWC.mValue = Convert.ToInt32(coord.September); nlist.Add(nvWC); }
            if (coord.October != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Ekim"; nvWC.mValue = Convert.ToInt32(coord.October); nlist.Add(nvWC); }
            if (coord.November != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Kasım"; nvWC.mValue = Convert.ToInt32(coord.November); nlist.Add(nvWC); }
            if (coord.December != 0) { nvWC = new DashWCapitalShortViewChart(); nvWC.mText = "Aralık"; nvWC.mValue = Convert.ToInt32(coord.December); nlist.Add(nvWC); }
            return nlist;
        }
    }
}
