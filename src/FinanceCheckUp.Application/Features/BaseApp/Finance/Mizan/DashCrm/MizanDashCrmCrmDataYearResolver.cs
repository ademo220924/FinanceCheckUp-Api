namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm;

/// <summary>
/// CRM pivot SQL yıllı filtre kullanır; kullanıcı seçimi (ör. 2026) veritabanındaki son yıldan büyükse sonuç boş gelir.
/// </summary>
internal static class MizanDashCrmCrmDataYearResolver
{
    public static int Resolve(int selectedYear, int? maxYearInTblXmlSourceOneT)
    {
        if (!maxYearInTblXmlSourceOneT.HasValue || maxYearInTblXmlSourceOneT.Value < 1900)
        {
            return selectedYear;
        }

        return Math.Min(selectedYear, maxYearInTblXmlSourceOneT.Value);
    }
}
