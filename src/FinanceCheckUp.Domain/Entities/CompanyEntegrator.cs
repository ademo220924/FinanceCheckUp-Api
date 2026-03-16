using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("CompanyEntegrator")]
public partial class CompanyEntegrator
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string CompanyName { get; set; }

    [StringLength(150)]
    public string ContactName { get; set; }

    [StringLength(150)]
    public string ContactMail { get; set; }

    [Column("ContactGSM")]
    [StringLength(150)]
    public string ContactGsm { get; set; }

    [Column("CityID")]
    public int? CityId { get; set; }

    [StringLength(150)]
    public string State { get; set; }

    [StringLength(450)]
    public string Adress { get; set; }

    [Column("TaxID")]
    [StringLength(150)]
    public string TaxId { get; set; }

    [StringLength(150)]
    public string TaxOffice { get; set; }

    [StringLength(850)]
    public string Notes { get; set; }

    public byte IsVisible { get; set; }
}
