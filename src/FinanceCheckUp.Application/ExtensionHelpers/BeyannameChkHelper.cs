using System.Globalization;

namespace FinanceCheckUp.Application.ExtensionHelpers
{
    public static class BeyannameChkHelper
    {
        public static string RemoveEmpty(string str, byte isreve)
        {
            List<string> nlist = str.Split(" ").ToList();
            if (nlist.Count < 3)
            {
                return string.Empty;
            }

            nlist.RemoveAt(nlist.Count - 1);
            if (isreve < 1)
            {
                nlist.RemoveAt(nlist.Count - 1);
            }

            string s = String.Join(" ", nlist.ToArray());

            if (s.Substring(0, 2) == ". ")
            {
                s = s.Substring(2);
            }

            return s;


        }
        public static double RemoveNonNumeric1(string str, byte isreve)
        {
            if (isreve > 0)
            {
                return 0;
            }


            string[] nlist = str.Split(" ");
            if (nlist.Length < 3)
            {
                return 0;
            }
            string s = nlist[nlist.Length - 2];




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
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
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
                chk = chk.Replace(addedPoint,
CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator);
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
    }
}
