
using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("Company")]
public class Company : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

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

    [Column("MainCompanyID")]
    public long MainCompanyId { get; set; }

    public int Year { get; set; }

    [Column("XmlSourceID")]
    public int? XmlSourceId { get; set; }

    [StringLength(50)]
    public string NaceCode { get; set; }

    public bool IsDeleted { get; set; }

    [Column("qnbUserId")]
    [StringLength(10)]
    public string QnbUserId { get; set; }

    [Column("qnbCorporateId")]
    [StringLength(11)]
    public string QnbCorporateId { get; set; }

    [Column("pidNo")]
    [StringLength(11)]
    public string PidNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    public string MainPlatform { get; set; }

    [Column("applicationId")]
    [StringLength(12)]
    public string ApplicationId { get; set; }

    [Column("transactionId")]
    [StringLength(55)]
    public string TransactionId { get; set; }

    [Column("NaceID")]
    public int? NaceId { get; set; }

    [StringLength(50)]
    public string CompanyStatus { get; set; }

    public int IsDefault { get; set; }
}
