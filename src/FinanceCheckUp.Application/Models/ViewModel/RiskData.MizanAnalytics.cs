using FinanceCheckUp.Application.Common.Constants;

namespace FinanceCheckUp.Application.Models.ViewModel;

/// <summary>
/// Web <c>fincheckup.Helper.Report.RiskData</c> ile aynı oran / renk puanlama mantığı.
/// </summary>
public partial class RiskData
{
    public static RiskData GetListedPoint(IEnumerable<ReportMainItem> listData)
    {
        var riskData = new RiskData();

        riskData.CariRate = listData.FirstOrDefault(x => x.TypeID == 11)?.TumYil ?? 0;
        riskData.TotalDebttoEquityRatio = listData.FirstOrDefault(x => x.TypeID == 141)?.TumYil ?? 0;
        riskData.LiquidityRatio = listData.FirstOrDefault(x => x.TypeID == 33)?.TumYil ?? 0;
        riskData.TotalBankBorrowingsVelocity = listData.FirstOrDefault(x => x.TypeID == 161)?.TumYil ?? 0;
        riskData.CashAssetRatio = listData.FirstOrDefault(x => x.TypeID == 55)?.TumYil ?? 0;
        riskData.ToplamAlacak171Devir = listData.FirstOrDefault(x => x.TypeID == 171)?.TumYil ?? 0;
        riskData.Equity = listData.FirstOrDefault(x => x.TypeID == 201)?.TumYil ?? 0;
        return riskData;
    }

    public static RiskData GetPoint(RiskData riskData)
    {
        var rand = new Random();
        if (riskData.CariRate < ReportRatioConstant.CariOran11Min)
        {
            if (riskData.CariRate < ReportRatioConstant.CariOranFailMax)
            {
                riskData.CariRatePoint = 7;
            }
            else
            {
                if (riskData.CariRate > 0.95f)
                    riskData.CariRatePoint = 2;
                else if (riskData.CariRate > 0.9f)
                    riskData.CariRatePoint = 3;
                else if (riskData.CariRate > 0.85f)
                    riskData.CariRatePoint = 4;
                else if (riskData.CariRate > 0.8f)
                    riskData.CariRatePoint = 5;
                else
                    riskData.CariRatePoint = 6;
            }
        }
        else
        {
            riskData.CariRatePoint = 1;
        }

        if (riskData.LiquidityRatio < ReportRatioConstant.LikitideOran33Min)
        {
            if (riskData.LiquidityRatio < ReportRatioConstant.LikitideOranFailMax)
            {
                riskData.LiquidityRatioPoint = 7;
            }
            else
            {
                if (riskData.LiquidityRatio > 0.95f)
                    riskData.LiquidityRatioPoint = 2;
                else if (riskData.LiquidityRatio > 0.9f)
                    riskData.LiquidityRatioPoint = 3;
                else if (riskData.LiquidityRatio > 0.85f)
                    riskData.LiquidityRatioPoint = 4;
                else if (riskData.LiquidityRatio > 0.8f)
                    riskData.LiquidityRatioPoint = 5;
                else
                    riskData.LiquidityRatioPoint = 6;
            }
        }
        else
        {
            riskData.LiquidityRatioPoint = 1;
        }

        if (riskData.CashAssetRatio < ReportRatioConstant.NakitOran55Min || riskData.CashAssetRatio > ReportRatioConstant.NakitOran55Max)
        {
            if (riskData.CashAssetRatio < ReportRatioConstant.NakitOran55MinFail ||
                riskData.CashAssetRatio > ReportRatioConstant.NakitOran55MaxFail)
            {
                riskData.CashAssetRatioPoint = 7;
            }
            else
            {
                riskData.CashAssetRatioPoint = rand.Next(2, 7);
            }
        }
        else
        {
            riskData.CashAssetRatioPoint = 1;
        }

        if (riskData.TotalBankBorrowingsVelocity < riskData.ToplamAlacak171Devir && riskData.TotalBankBorrowingsVelocity != 0)
        {
            if (riskData.ToplamAlacak171Devir - riskData.TotalBankBorrowingsVelocity > 10)
                riskData.TotalBankBorrowingsVelocityPoint = 7;
            else
                riskData.TotalBankBorrowingsVelocityPoint = rand.Next(2, 7);
        }
        else
        {
            riskData.TotalBankBorrowingsVelocityPoint = 1;
        }

        if (riskData.TotalDebttoEquityRatio > ReportRatioConstant.ToplamBorcOzsermayeOran141Max)
        {
            if (riskData.TotalDebttoEquityRatio > ReportRatioConstant.ToplamBorcOzsermayeOranFailMin)
            {
                riskData.TotalDebttoEquityRatioPoint = 7;
            }
            else
            {
                if (riskData.TotalDebttoEquityRatio < 0.25f)
                    riskData.TotalDebttoEquityRatioPoint = 2;
                else if (riskData.TotalDebttoEquityRatio < 0.3f)
                    riskData.TotalDebttoEquityRatioPoint = 3;
                else if (riskData.TotalDebttoEquityRatio < 0.35f)
                    riskData.TotalDebttoEquityRatioPoint = 4;
                else if (riskData.TotalDebttoEquityRatio < 0.4f)
                    riskData.TotalDebttoEquityRatioPoint = 5;
                else
                    riskData.TotalDebttoEquityRatioPoint = 6;
            }
        }
        else
        {
            riskData.TotalDebttoEquityRatioPoint = 1;
        }

        if (riskData.Equity < ReportRatioConstant.OzkaynakAktifToplamOran201Min)
        {
            if (riskData.Equity < ReportRatioConstant.OzkaynakAktifToplamOran201MinFail)
            {
                riskData.EquityPoint = 7;
            }
            else
            {
                if (riskData.Equity > -0.9f)
                    riskData.EquityPoint = 2;
                else if (riskData.Equity > -0.85f)
                    riskData.EquityPoint = 3;
                else if (riskData.Equity > -0.8f)
                    riskData.EquityPoint = 4;
                else if (riskData.Equity > -0.7f)
                    riskData.EquityPoint = 5;
                else
                    riskData.EquityPoint = 6;
            }
        }
        else
        {
            riskData.EquityPoint = 1;
        }

        return riskData;
    }
}
