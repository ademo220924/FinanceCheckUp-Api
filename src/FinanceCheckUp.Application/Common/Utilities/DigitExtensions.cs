namespace FinanceCheckUp.Application.Common.Utilities;

public static class DigitExtensions
{
    public static double ConvertDec(string datta)
    {
        var isNumber = double.TryParse(datta, out var numvalue);
        return isNumber ? numvalue : 0;
    }
    public static string ConvertDatum(string datta)
    {
        var listo = datta[..10].Replace("-", ".").Replace("/", ".").Split('.');
        return listo[0] + "." + listo[2] + '.' + listo[1];
    }

    public static bool IsNumeric(object Expression)
    {
        double retNum;

        bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }
}