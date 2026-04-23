namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Services;

/// <summary>
/// Web tarafında <c>Startup.FooServiceInstance.FirstSetupAsync</c> ile üretilen metin (RTF) karşılığı.
/// Gerçek LLM entegrasyonu için uygulama içinde yeniden kayıt edilebilir.
/// </summary>
public interface IMizanFinancialNarrativeService
{
    Task<string> GetMizanNarrativeAsync(string csvPayload, CancellationToken cancellationToken = default);
}
