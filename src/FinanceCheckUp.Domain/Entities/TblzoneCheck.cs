using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLZoneCheck")]
public partial class TblzoneCheck
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("AccountMainID")]
    [StringLength(250)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    public double? January { get; set; }

    public double? February { get; set; }

    public double? March { get; set; }

    public double? April { get; set; }

    public double? May { get; set; }

    public double? June { get; set; }

    public double? July { get; set; }

    public double? August { get; set; }

    public double? September { get; set; }

    public double? October { get; set; }

    public double? November { get; set; }

    public double? December { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int Year { get; set; }
}
