using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLDataErrored")]
public partial class TbldataErrored
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string EntryNumber { get; set; }

    [StringLength(250)]
    public string DocumentDate { get; set; }

    [StringLength(250)]
    public string EnteredBy { get; set; }

    [Column("AccountMainID")]
    [StringLength(250)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    [Column("AccountSubID")]
    [StringLength(250)]
    public string AccountSubId { get; set; }

    [StringLength(250)]
    public string AccountSubDescription { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    public double? Amount { get; set; }

    [StringLength(450)]
    public string DetailComment { get; set; }

    [StringLength(250)]
    public string PaymentMethod { get; set; }

    [StringLength(450)]
    public string DocumentTypeDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column("CompanyID")]
    public long CompanyId { get; set; }

    public int Year { get; set; }
}
