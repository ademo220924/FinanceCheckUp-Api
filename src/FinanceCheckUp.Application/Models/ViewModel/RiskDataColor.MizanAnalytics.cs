namespace FinanceCheckUp.Application.Models.ViewModel;

/// <summary>
/// Web <c>fincheckup.Helper.Report.RiskDataColor</c> ile aynı sektörel karşılaştırma puanı.
/// </summary>
public partial class RiskDataColor
{
    public static RiskDataColor GetListedPoint(List<ReportMainItem> listData, int orderId, bool negatif, RiskDataColor riskData)
    {
        if (listData == null || listData.Count == 0)
            return riskData;

        var yearlast = listData.Max(x => x.Year);
        var count = listData.Count;
        var point = 0;
        var lastvalue = listData.Where(x => x.Year == yearlast).Select(z => z.TumYil).FirstOrDefault();
        var totalvalue = listData.Where(x => x.Year != yearlast).Sum(z => z.TumYil) / count;
        var percntge = totalvalue != 0 ? lastvalue / totalvalue : 0f;

        if (negatif)
        {
            if (percntge < 0.1f) point = 1;
            else if (percntge < 0.05f) point = 2;
            else if (percntge > 1.5f) point = 5;
            else if (percntge > 1f) point = 4;
            else if (percntge > 0) point = 3;
        }
        else
        {
            if (percntge < 0.1f) point = 5;
            else if (percntge < 0.05f) point = 4;
            else if (percntge > 1.5f) point = 1;
            else if (percntge > 1f) point = 2;
            else if (percntge > 0) point = 3;
        }

        switch (orderId)
        {
            case 1: riskData.ncheck1 = lastvalue; riskData.ncheck1Point = point; break;
            case 2: riskData.ncheck2 = lastvalue; riskData.ncheck2Point = point; break;
            case 3: riskData.ncheck3 = lastvalue; riskData.ncheck3Point = point; break;
            case 4: riskData.ncheck4 = lastvalue; riskData.ncheck4Point = point; break;
            case 5: riskData.ncheck5 = lastvalue; riskData.ncheck5Point = point; break;
            case 6: riskData.ncheck6 = lastvalue; riskData.ncheck6Point = point; break;
            case 7: riskData.ncheck7 = lastvalue; riskData.ncheck7Point = point; break;
            case 8: riskData.ncheck8 = lastvalue; riskData.ncheck8Point = point; break;
            case 9: riskData.ncheck9 = lastvalue; riskData.ncheck9Point = point; break;
            case 10: riskData.ncheck10 = lastvalue; riskData.ncheck10Point = point; break;
            case 11: riskData.ncheck11 = lastvalue; riskData.ncheck11Point = point; break;
            case 12: riskData.ncheck12 = lastvalue; riskData.ncheck12Point = point; break;
        }

        return riskData;
    }
}
