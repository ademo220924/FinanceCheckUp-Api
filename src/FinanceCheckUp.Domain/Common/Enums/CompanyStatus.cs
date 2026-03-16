using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Enums;

public enum CompanyStatus
{
    [Description("Kayıtlı")]
    Kayıtlı = 1,
    [Description("Kayıtsız")]
    Kayıtsız,
    [Description("İptalKayıt")]
    İptalKayıt
}
