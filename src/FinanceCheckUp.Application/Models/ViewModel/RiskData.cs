namespace FinanceCheckUp.Application.Models.ViewModel;

public class RiskData
{
    public int CariRatePoint { get; set; }
    public float CariRate { get; set; }

    public int TotalDebttoEquityRatioPoint { get; set; }
    public float TotalDebttoEquityRatio { get; set; }

    public int LiquidityRatioPoint { get; set; }
    public float LiquidityRatio { get; set; }

    public int TotalBankBorrowingsVelocityPoint { get; set; }
    public float TotalBankBorrowingsVelocity { get; set; }

    public int CashAssetRatioPoint { get; set; }
    public float CashAssetRatio { get; set; }

    public int EquityPoint { get; set; }
    public float Equity { get; set; }

    public float ToplamAlacak171Devir  { get; set; }
}