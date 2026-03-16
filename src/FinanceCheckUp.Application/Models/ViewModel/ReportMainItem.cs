
namespace FinanceCheckUp.Application.Models.ViewModel;
public class ReportMainItem
{
    public float Q1 { get; set; }
    public float Q2 { get; set; }
    public float Q3 { get; set; }
    public float TumYil { get; set; }
    public long CompanyID { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int CounterZone { get; set; }
    public int TypeID { get; set; }


    public byte IsFailed { get; set; }
    public string Q1Tx1A
    {
        get { if (Q1 < 10000) { return (Q1).ToString("N2"); } else { return Q1.ToString("N0"); }; }
        set { }
    }
    public string Q2Tx1A
    {
        get { if (Q2 < 10000) { return (Q2).ToString("N2"); } else { return Q2.ToString("N0"); }; }
        set { }
    }
    public string Q3Tx1A
    {
        get { if (Q3 < 10000) { return (Q3).ToString("N2"); } else { return Q3.ToString("N0"); }; }
        set { }
    }
    public string TumYilTx1A
    {
        get { if (TumYil < 10000) { return (TumYil).ToString("N2"); } else { return TumYil.ToString("N0"); }; }
        set { }
    }
    public string Q1Tx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q1 * 100).ToString("N1"); } else { return Q1.ToString("N2"); }; }
        set { }
    }
    public string Q2Tx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q2 * 100).ToString("N1"); } else { return Q2.ToString("N2"); }; }
        set { }
    }
    public string Q3Tx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q3 * 100).ToString("N1"); } else { return Q3.ToString("N2"); }; }
        set { }
    }
    public string TumYilTx1
    {
        get { if (GroupName.Contains("%")) { return "%" + (TumYil * 100).ToString("N1"); } else { return TumYil.ToString("N2"); }; }
        set { }
    }
    public string Q1Tx
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q1 * 100).ToString("N1"); } else { return Q1.ToString("N0"); }; }
        set { }
    }
    public string Q2Tx
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q2 * 100).ToString("N1"); } else { return Q2.ToString("N0"); }; }
        set { }
    }
    public string Q3Tx
    {
        get { if (GroupName.Contains("%")) { return "%" + (Q3 * 100).ToString("N1"); } else { return Q3.ToString("N0"); }; }
        set { }
    }
    public string TumYilTx
    {
        get { if (GroupName.Contains("%")) { return "%" + (TumYil * 100).ToString("N1"); } else { return TumYil.ToString("N0"); }; }
        set { }
    }

}