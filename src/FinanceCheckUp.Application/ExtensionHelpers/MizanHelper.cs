using FinanceCheckUp.Application.Models.ViewModel.Mizan;
using System.Globalization;

namespace FinanceCheckUp.Application.ExtensionHelpers;

public static class MizanHelper
{
    public static TBLXMLSCheckpdfMizan checkStrList(List<string> nmon)
    {

        TBLXMLSCheckpdfMizan nlistitem = new TBLXMLSCheckpdfMizan();

        int nm = nmon.Count;
        if (nmon.Count >= 6)
        {
            List<int> tlist = new List<int>() { 0, nm - 1, nm - 2, nm - 3, nm - 4 };

            nlistitem.AccountMainID = nmon[0];
            nlistitem.Amount1 = RemoveNonNumeric2(nmon[nm - 4]);
            nlistitem.Amount2 = RemoveNonNumeric2(nmon[nm - 3]);
            nlistitem.Amount3 = RemoveNonNumeric2(nmon[nm - 2]);
            nlistitem.Amount4 = RemoveNonNumeric2(nmon[nm - 1]);
            for (int i = 1; i < nmon.Count; i++)
            {
                if (!tlist.Contains(i))
                {
                    nlistitem.AccountMainDescription += nmon[i] + ' ';
                }

            }

        }

        return nlistitem;

    }


    public static double RemoveNonNumeric2(string str)
    {
        string[] nlist = str.Split(" ");

        string s = nlist[nlist.Length - 1];


        CultureInfo ci = CultureInfo.GetCultureInfo("tr-TR");
        string chk = string.Empty;
        chk = string.Concat(s?.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

        if (chk.Trim().Length < 2 && (chk.Trim() == "-" || chk.Trim() == ")" || chk.Trim() == "(") || chk.Trim().Length < 1)
        {
            chk = "0";
        }

        if (chk.IndexOf("(") >= 0 && chk.IndexOf(")") >= 0)
        {
            chk = chk.Replace("(", "-").Replace(")", string.Empty);

        }
        string addedPoint = string.Empty;
        string addedDecimal = string.Empty;
        chk = chk.Trim();
        if (chk.Length < 2 && chk == "-" || chk.Length < 1)
        {
            chk = "0";
        }

        if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
        {
            addedPoint = ",";
            addedDecimal = chk.Substring(chk.Length - 1);
            chk = chk.Substring(0, chk.Length - 2);

        }


        if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
        {
            addedPoint = ",";
            addedDecimal = chk.Substring(chk.Length - 2);
            chk = chk.Substring(0, chk.Length - 3);

        }

        if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
        {
            addedPoint = ".";
            addedDecimal = chk.Substring(chk.Length - 1);
            chk = chk.Substring(0, chk.Length - 2);

        }


        if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
        {
            addedPoint = ".";
            addedDecimal = chk.Substring(chk.Length - 2);
            chk = chk.Substring(0, chk.Length - 3);

        }



        chk = chk.Replace(",", string.Empty).Replace(".", string.Empty);
        chk = chk + addedPoint + addedDecimal;
        if (addedPoint.Length > 0)
        {
            chk = chk.Replace(addedPoint, CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
        }



        try
        {


            var result = double.Parse(chk, NumberStyles.AllowDecimalPoint | NumberStyles.Number, CultureInfo.InvariantCulture);
            return result;
            // return chk.ToDecimalInvariant();// Convert.ToDouble(chk,CultureInfo.InvariantCulture.NumberFormat);

        }
        catch
        {
            var tt = chk;
            return 0;
        }

    }

    public static List<TBLXMLSCheckpdfMizan> getlimited(List<TBLXMLSCheckpdfMizancHK> ndor)
    {
        List<TBLXMLSCheckpdfMizan> nbi = ndor.Select(x => new TBLXMLSCheckpdfMizan()
        {
            AccountMainID = x.AccountMainID,
            AccountMainDescription = x.AccountMainDescription,
            Amount1 = x.Amount1,
            Amount2 = x.Amount2,
            Amount3 = x.Amount3,
            Amount4 = x.Amount4,
            PageID = x.pageID,
        }).ToList();
        return nbi;
    }

    public static List<TBLXMLSCheckpdfMizancHK> getSplistedt(List<string> dodo)
    {
        List<TBLXMLSCheckpdfMizancHK> nmizamna = new List<TBLXMLSCheckpdfMizancHK>();
        TBLXMLSCheckpdfMizancHK nmizamn = new TBLXMLSCheckpdfMizancHK();
        foreach (var item in dodo)
        {


            nmizamn = new TBLXMLSCheckpdfMizancHK();
            string ntcxt = item.Substring(1);
            ntcxt = ntcxt.Remove(ntcxt.Length - 1, 1).Replace("ßß", "ß");
            List<string> flist = ntcxt.Split('ß').ToList();
            if (flist.Count > 0 && flist[0].Length < 3)
            {
                flist.RemoveAt(0);
            }

            if (flist.Count > 0 && flist[0].Length < 3)
            {
                flist.RemoveAt(0);
            }



            if (flist.Count == 6)
            {
                nmizamn.AccountMainID = flist[0];
                nmizamn.AccountMainDescription = flist[1];
                nmizamn.Amount4 = RemoveNonNumeric2(flist[5]);
                nmizamn.Amount3 = RemoveNonNumeric2(flist[4]);
                nmizamn.Amount2 = RemoveNonNumeric2(flist[3]);
                nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);
            }
            else if (flist.Count == 5)
            {
                nmizamn.AccountMainID = flist[0];
                nmizamn.AccountMainDescription = flist[1];
                nmizamn.Amount3 = RemoveNonNumeric2(flist[4]);
                nmizamn.Amount2 = RemoveNonNumeric2(flist[3]);
                nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);

            }
            else if (flist.Count == 4)
            {
                nmizamn.AccountMainID = flist[0];
                nmizamn.AccountMainDescription = flist[1];
                nmizamn.Amount2 = RemoveNonNumeric2(flist[3]);
                nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);

            }
            else if (flist.Count == 3)
            {

                nmizamn.AccountMainID = flist[0];
                nmizamn.AccountMainDescription = flist[1];
                nmizamn.Amount1 = RemoveNonNumeric2(flist[2]);
            }
            else if (flist.Count == 2)
            {

                nmizamn.AccountMainID = flist[0];
                nmizamn.AccountMainDescription = flist[1];
            }
            nmizamna.Add(nmizamn);
        }

        return nmizamna;
    }

    public static TBLXMLSCheckpdfMizancHK getSplisted(string[] dodo)
    {
        TBLXMLSCheckpdfMizancHK nmizamn = new TBLXMLSCheckpdfMizancHK();
        float f;
        int t;
        bool numeric = false;
        List<double> flist = new List<double>();
        int countre = 0;
        bool ntec = true;
        for (int i = dodo.Length - 1; i >= 0; i--)
        {
            countre++;

            if (float.TryParse(dodo[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty), out f) && ntec == true)
            {
                flist.Add(RemoveNonNumeric2(dodo[i]));
            }
            else
            {
                ntec = false;
                nmizamn.lineMainDescription += dodo[i] + ' ';
            }
        }

        string[] strlist = nmizamn.lineMainDescription.Split(' ');
        ntec = true;
        for (int i = strlist.Length - 1; i >= 0; i--)
        {
            if (int.TryParse(strlist[i].Replace(",", string.Empty).Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty), out t) && ntec == true)
            {

                nmizamn.AccountMainID += strlist[i] + ".";


            }
            else
            {
                if (nmizamn.AccountMainID.Length > 0)
                {
                    nmizamn.AccountMainID = nmizamn.AccountMainID.Remove(nmizamn.AccountMainID.Length - 1, 1);
                }

                ntec = false;
                nmizamn.AccountMainDescription += strlist[i] + ' ';
            }
        }

        if (flist.Count == 4)
        {
            nmizamn.Amount4 = flist[0];
            nmizamn.Amount3 = flist[1];
            nmizamn.Amount2 = flist[2];
            nmizamn.Amount1 = flist[3];
        }
        else if (flist.Count == 3)
        {
            nmizamn.Amount3 = flist[0];
            nmizamn.Amount2 = flist[1];
            nmizamn.Amount1 = flist[2];

        }
        else if (flist.Count == 2)
        {

            nmizamn.Amount2 = flist[0];
            nmizamn.Amount1 = flist[1];

        }
        else if (flist.Count == 1)
        {

            nmizamn.Amount1 = flist[0];
        }
        return nmizamn;
    }


}