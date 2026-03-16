namespace FinanceCheckUp.Client.QnbClient.Models.Request;

public class BrandedPaymentRequest
{
    public Settings _settings { get; set; }

    public string CurrencyCode { private get; set; }
    public Invoice Invoice { private get; set; }
    public string Name { private get; set; }
    public string SurName { private get; set; }

    public string currency_code { get { return this.CurrencyCode; } }
    public Invoice invoice { get { return this.Invoice; } }
    public string name { get { return this.Name; } }
    public string surname { get { return this.SurName; } }

    public BrandedPaymentRequest(Settings settings)
    {
        this._settings = settings;
    }

}