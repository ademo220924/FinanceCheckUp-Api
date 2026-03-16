
namespace FinanceCheckUp.Application.Models;
public class DashBilancoView
{
    public string AccountMainID { get; set; }
    public string AccountMainDescription { get; set; }
    public string DebitCreditCode { get; set; }
    public double Acilis { get; set; }
    public double January { get; set; }
    public double February { get; set; }
    public double March { get; set; }
    public double April { get; set; }
    public double May { get; set; }
    public double June { get; set; }
    public double July { get; set; }
    public double August { get; set; }
    public double September { get; set; }
    public double October { get; set; }
    public double November { get; set; }
    public double December { get; set; }

    public long CompanyID { get; set; }
    public int IsHidden { get; set; }
    public int Year { get; set; }
    public string GroupName { get; set; }
    public int CounterZone { get; set; }
    public int TypeID { get; set; }
    public string QnbDescription { get; set; }
    public Int64 OverViewTotal => Convert.ToInt64(September + October + November + May + March + June + July + January + February + December + August + April);
    public Int64 getTotalInt()
    {

        return Convert.ToInt64(September + October + November + May + March + June + July + January + February + December + August + April);
    }
    public double getTotaldecimal()
    {

        return September + October + November + May + March + June + July + January + February + December + August + April;
    }

    public bool getStatue()
    {
        int ncoun = 0;
        Boolean chk = true;
        if (September != 0) { ncoun++; }
        if (October != 0) { ncoun++; }
        if (November != 0) { ncoun++; }
        if (May != 0) { ncoun++; }
        if (March != 0) { ncoun++; }
        if (June != 0) { ncoun++; }
        if (July != 0) { ncoun++; }
        if (January != 0) { ncoun++; }
        if (February != 0) { ncoun++; }
        if (December != 0) { ncoun++; }
        if (August != 0) { ncoun++; }
        if (April != 0) { ncoun++; }
        if (ncoun == 0)
        {
            chk = false;
        }

        return chk;
    }

    public string getAvaerageString()
    {
        int ncoun = 0;
        if (September != 0) { ncoun++; }
        if (October != 0) { ncoun++; }
        if (November != 0) { ncoun++; }
        if (May != 0) { ncoun++; }
        if (March != 0) { ncoun++; }
        if (June != 0) { ncoun++; }
        if (July != 0) { ncoun++; }
        if (January != 0) { ncoun++; }
        if (February != 0) { ncoun++; }
        if (December != 0) { ncoun++; }
        if (August != 0) { ncoun++; }
        if (April != 0) { ncoun++; }
        if (ncoun == 0)
        {
            return "0";
        }
        else
        {
            return ((September + October + November + May + March + June + July + January + February + December + August + April) / Convert.ToDouble(ncoun)).ToString("0.00");
        }

    }

}
