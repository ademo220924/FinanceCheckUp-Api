namespace FinanceCheckUp.Application.Models
{
    public class DashBilancoViewTx
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
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }
        public int IsHidden { get; set; }

        public double JanuaryTx => January;
        public double FebruaryTx => February != 0 ? January + February : 0;
        public double MarchTx => March != 0 ? January + February + March : 0;
        public double AprilTx => April != 0 ? January + February + March + April : 0;
        public double MayTx => May != 0 ? January + February + March + April + May : 0;
        public double JuneTx => June != 0 ? January + February + March + April + May + June : 0;
        public double JulyTx => July != 0 ? January + February + March + April + May + June + July : 0;
        public double AugustTx => August != 0 ? January + February + March + April + May + June + July + August : 0;
        public double SeptemberTx => September != 0 ? January + February + March + April + May + June + July + August + September : 0;
        public double OctoberTx => October != 0 ? January + February + March + April + May + June + July + August + September + October : 0;
        public double NovemberTx => November != 0 ? January + February + March + April + May + June + July + August + September + October + November : 0;
        public double DecemberTx => December != 0 ? January + February + March + April + May + June + July + August + September + October + November + December : 0;




        public static List<DashBilancoViewTx> setDashBilanco(List<DashBilancoView> mdash)
        {
            List<DashBilancoViewTx> nlist = new List<DashBilancoViewTx>();

            nlist = mdash.Select(x => new DashBilancoViewTx()
            {
                AccountMainID = x.AccountMainID,
                AccountMainDescription = x.AccountMainDescription,
                DebitCreditCode = x.DebitCreditCode,
                Acilis = x.Acilis,
                January = x.January,
                February = x.February,
                March = x.March,
                April = x.April,
                May = x.May,
                June = x.June,
                July = x.July,
                August = x.August,
                September = x.September,
                October = x.October,
                November = x.November,
                December = x.December,
                CompanyID = x.CompanyID,
                Year = x.Year,
                GroupName = x.GroupName,
                CounterZone = x.CounterZone,
                TypeID = x.TypeID,
                IsHidden = x.IsHidden
            }).ToList();
            return nlist;

        }

    }
}
