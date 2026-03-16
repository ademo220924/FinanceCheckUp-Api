using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMDONUKACCNTCHK")]
public partial class Tblmdonukaccntchk
{
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

    public double? January { get; set; }

    public double? February { get; set; }

    public double? March { get; set; }

    public byte? MarchT { get; set; }

    public double? April { get; set; }

    public double? May { get; set; }

    public double? June { get; set; }

    public byte? JuneT { get; set; }

    public double? July { get; set; }

    public double? August { get; set; }

    public double? September { get; set; }

    public byte? SeptemberT { get; set; }

    public double? October { get; set; }

    public double? November { get; set; }

    public double? December { get; set; }

    public byte? DecemberT { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [Column("OrderID")]
    public byte? OrderId { get; set; }

    [StringLength(50)]
    public string GroupName { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
