namespace FinanceCheckUp.Domain.Dtos.BaseApp;

public class GetCompanyByUserDto
{
    public List<GetCompanyByUserDtoItem> Items { get; set; }
}

public class GetCompanyByUserDtoItem
{
    public long Id { get; set; }
    public string CompanyName { get; set; }
    public int? NaceId { get; set; }
    public string TaxId { get; set; }
    public string NaceCode { get; set; }
    public string CityName { get; set; }
    public byte IsDefault { get; set; }
}