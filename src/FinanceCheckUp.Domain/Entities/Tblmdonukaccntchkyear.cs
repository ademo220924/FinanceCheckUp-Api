using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMDONUKACCNTCHKYEAR")]
public partial class Tblmdonukaccntchkyear
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

    public double? Amount { get; set; }

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
