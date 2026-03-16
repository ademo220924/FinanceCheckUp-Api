using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FinanceCheckUp.Application.Common.Utilities;

public static class StringExtension
{
    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        return str.Length > 1
            ? char.ToLowerInvariant(str[0]) + str[1..]
            : str.ToLowerInvariant();
    }

    public static string ToSlug(this string value)
    {
        value = value.Replace("I", "i").Replace("İ", "i").Replace("ı", "i");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
        var output = Encoding.ASCII.GetString(bytes).ToLower(CultureInfo.InvariantCulture);
        output = Regex.Replace(output, @"[^A-Za-z0-9\s-]", "");
        output = Regex.Replace(output, @"\s+", " ").Trim();
        output = Regex.Replace(output, @"\s", "-");
        return output;
    }

    public static double CompareStrings(string str1, string str2)
    {
        List<string> pairs1 = WordLetterPairs(str1.ToUpper());
        List<string> pairs2 = WordLetterPairs(str2.ToUpper());

        int intersection = 0;
        int union = pairs1.Count + pairs2.Count;

        for (int i = 0; i < pairs1.Count; i++)
        {
            for (int j = 0; j < pairs2.Count; j++)
            {
                if (pairs1[i] == pairs2[j])
                {
                    intersection++;
                    pairs2.RemoveAt(j);//Must remove the match to prevent "AAAA" from appearing to match "AA" with 100% success
                    break;
                }
            }
        }

        return (2.0 * intersection * 100) / union; //returns in percentage
                                                   //return (2.0 * intersection) / union; //returns in score from 0 to 1
    }


    private static List<string> WordLetterPairs(string str)
    {
        List<string> AllPairs = new List<string>();

        // Tokenize the string and put the tokens/words into an array
        string[] Words = Regex.Split(str, @"\s");

        // For each word
        for (int w = 0; w < Words.Length; w++)
        {
            if (!string.IsNullOrEmpty(Words[w]))
            {
                // Find the pairs of characters
                String[] PairsInWord = LetterPairs(Words[w]);

                for (int p = 0; p < PairsInWord.Length; p++)
                {
                    AllPairs.Add(PairsInWord[p]);
                }
            }
        }
        return AllPairs;
    }

    private static string[] LetterPairs(string str)
    {
        int numPairs = str.Length - 1;
        string[] pairs = new string[numPairs];

        for (int i = 0; i < numPairs; i++)
        {
            pairs[i] = str.Substring(i, 2);
        }
        return pairs;
    }

    public static string RemoveStringDiff(string str1, string str2)
    {
        int countrr = 0;
        string lastret = "";
        string nret = "";
        int obara = 0;
        int fan = str1.Length - str2.Length;



        try
        {
            string rpplcedstr = str1.Trim().Replace(str2, "");
            if (rpplcedstr != str1.Trim())
            {
                return rpplcedstr;

            }

            for (int i = str1.Length - 1; i >= 0; i--)
            {
                if (str1[i] == str2[i - fan])
                {
                    lastret += str1[i];
                }
                else
                {
                    break;
                }

            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    countrr = i;
                    break;
                    nret += str1[i];
                }
            }
            char[] charArray = lastret.ToCharArray();
            Array.Reverse(charArray);
            string lastchek = new string(charArray);
            string ttetet = str1.Substring(countrr);
            var chk = lastret;
            var chkss = nret;
            nret = ttetet.Trim().Replace(lastchek, "");

            return nret;

        }
        catch (Exception ex)
        {

            var chkzzz = ex;
        }



        return nret;
    }


    public static string GetDataConvertedData(string textFromPage)
    {
        var texts = textFromPage.Split(new[] { "\n" }, StringSplitOptions.None)
                                .Where(text => text.Contains("Tj")).ToList();

        return texts.Aggregate(string.Empty, (current, t) => current +
                   t.TrimStart('(')
                    .TrimEnd('j')
                    .TrimEnd('T')
                    .TrimEnd(')'));
    }


    public static string GetgetSterlin(Double count)
    {
        string txt = string.Empty;
        for (int i = 0; i < count; i++)
        {
            txt += "£";
        }
        return txt;
    }
}