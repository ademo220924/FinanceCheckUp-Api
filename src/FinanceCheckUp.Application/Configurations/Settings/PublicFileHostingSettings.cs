namespace FinanceCheckUp.Application.Configurations.Settings;

/// <summary>
/// PDF gibi dosyaların tarayıcıda açılması için kullanılacak mutlak URL kökü (scheme + host + isteğe bağlı port).
/// Bu bir disk yolu değildir; <see cref="BaseUrl"/> mutlaka kullanıcının tarayıcısından HTTP(S) ile erişilebilir olmalıdır.
/// </summary>
/// <remarks>
/// <para><b>API henüz dışarı açık değilse:</b> Buraya gerçekten çözülemeyen bir alan adı (ör. sadece planlanan
/// <c>https://finance-api.sirketiniz.com</c>) yazmak işe yaramaz; PDF linki kırılır.</para>
/// <para>Uygun seçenekler: (1) QA’da API’yi aynı makinede çalıştırıp <c>http://localhost:2025</c> gibi tarayıcıdan
/// erişilen adres; (2) ofis/VPN içi gerçek iç adres (ör. <c>http://10.x.x.x:2025</c>); (3) geçici tünel (ngrok vb.);
/// (4) <see cref="BaseUrl"/> boş bırakılıp Web tarafında API’den dosyayı sunucu üzerinden proxy’leyen bir endpoint
/// (henüz yoksa eklenmeli).</para>
/// </remarks>
public class PublicFileHostingSettings
{
    /// <summary>
    /// Sonunda / olmamalı. Boş bırakılırsa API yalnızca göreli yol (<c>FileContent/...</c>) döner; Web farklı host’ta
    /// ise tarayıcı yine Web host’una gider — bu yüzden çoklu sunucuda genelde dolu olmalıdır.
    /// </summary>
    public string BaseUrl { get; set; } = "";
}
