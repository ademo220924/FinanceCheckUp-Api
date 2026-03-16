using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;

public enum JobStatus
{
    [Description("Oluşturuldu")] Created = 1,
    [Description("Çalışıyor")] Processing = 2,
    [Description("Tamamlandı")] Completed = 3,
    [Description("Tekrarlanacak")] Retried = 4
}