namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Services;

/// <summary>
/// Varsayılan: AI yokken bile substring/RTF atamasının güvenle çalışması için minimal RTF.
/// </summary>
public sealed class PlaceholderMizanFinancialNarrativeService : IMizanFinancialNarrativeService
{
    public Task<string> GetMizanNarrativeAsync(string csvPayload, CancellationToken cancellationToken = default)
    {
        _ = csvPayload;
        const string minimal =
            "{\\rtf1\\ansi\\deff0 Dönen Varlıklar **Varlıklar** Özet metin henüz yapılandırılmadı.\\par}";
        return Task.FromResult(minimal);
    }
}
