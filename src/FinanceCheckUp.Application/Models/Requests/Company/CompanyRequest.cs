namespace fincheckup.ApiClients.Models.Requests.Company;

public class CompanyRequest
{
    public string Address { get; set; }
    public int CityId { get; set; }
    public string CompanyName { get; set; }
    public string ContactGsm { get; set; }
    public string ContactMail { get; set; }
    public string TaxId { get; set; }
    public string TaxOffice { get; set; }
    public string Notes { get; set; }
    public string ContactName { get; set; }
    public string NaceCode { get; set; }
    public int MainCompanyId { get; set; }
    public int XmlSourceId { get; set; }
    public string State { get; set; }
}
