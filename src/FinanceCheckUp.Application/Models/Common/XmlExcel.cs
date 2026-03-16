using System.Globalization;

namespace FinanceCheckUp.Application.Models.Common;

public class XmlExcel
{
    public long CompanyId { get; set; }
    public int Year { get; set; }
    public int MainMonth { get; set; }
    public long CsvId { get; set; }
    private string accountMainID { get; set; }
    public string AccountMainID
    {
        get => accountMainID;
        set => accountMainID = value ?? string.Empty;
    }

    public string AccountMainDescription { get; set; }
    public string DebitAmount { get; set; }
    public string CreditAmount { get; set; }
    public string AmountBakiye { get; set; }
    public string AccountMainIDMain => AccountMainID is { Length: > 2 } ? AccountMainID[..3] : string.Empty;
    private double amountBakiyeFloat { get; set; }
    private double debitAmountFloat { get; set; }
    private double creditAmountFloat { get; set; }
    private string AmountBakiyeTxa { get; set; }
    private string creditAmountTxa { get; set; }
    private string DebitAmountTxa { get; set; }
    private string AmountBakiyeTx => string.IsNullOrEmpty(AmountBakiye) ? "0" : AmountBakiye.Replace(" ", string.Empty);
    private string creditAmountTx => string.IsNullOrEmpty(CreditAmount) ? "0" : CreditAmount.Replace(" ", string.Empty);
    private string DebitAmountTx => string.IsNullOrEmpty(DebitAmount) ? "0" : DebitAmount.Replace(" ", string.Empty);

    public double AmountBakiyeFloat => RemoveNonNumeric2(AmountBakiyeTx);

    public double CreditAmountFloat => RemoveNonNumeric2(creditAmountTx);

    public double DebitAmountFloat => RemoveNonNumeric2(DebitAmountTx);

    public string AmountCredit { get; set; }
    public int DotSplitCount => AccountMainID != null ? AccountMainID.Split('.').Count() : 0;
    public int TextCount => AccountMainID != null ? AccountMainID.Replace(" ", string.Empty).Replace(".", string.Empty).Trim().Count() : 0;

    private static double RemoveNonNumeric2(string s)
    {
        var ci = CultureInfo.GetCultureInfo("tr-TR");
        var chk = string.Concat(s.Where(c => char.IsNumber(c) || c == '.' || c == ',' || c == '-' || c == '(' || c == ')') ?? string.Empty);

        if (!string.IsNullOrEmpty(chk) && chk.Trim().Length < 2 && chk.Trim() == "-" || chk.Trim().Length < 1)
        {
            chk = "0";
        }

        if (!string.IsNullOrEmpty(chk) && chk.Contains('(') && chk.Contains(')'))
        {
            chk = chk.Replace("(", "-").Replace(")", string.Empty);

        }

        var addedPoint = string.Empty;
        var addedDecimal = string.Empty;
        chk = chk.Trim();
        if (chk.Length < 2 && chk == "-" || chk.Length < 1)
        {
            chk = "0";
        }

        if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ",")
        {
            addedPoint = ",";
            addedDecimal = chk[^1..];
            chk = chk[..^2];

        }


        if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ",")
        {
            addedPoint = ",";
            addedDecimal = chk[^2..];
            chk = chk[..^3];

        }

        if (chk.Length >= 2 && chk.Substring(chk.Length - 2, 1) == ".")
        {
            addedPoint = ".";
            addedDecimal = chk[^1..];
            chk = chk[..^2];

        }


        if (chk.Length >= 3 && chk.Substring(chk.Length - 3, 1) == ".")
        {
            addedPoint = ".";
            addedDecimal = chk[^2..];
            chk = chk[..^3];

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
        }
        catch (Exception)
        {
            return double.Parse(chk, CultureInfo.InvariantCulture);
        }

    }


}
