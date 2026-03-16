using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("SPO_TBMLAKTARMA")]
public partial class SpoTbmlaktarma
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column("YEAR")]
    public int? Year { get; set; }

    public int? Value { get; set; }

    [StringLength(451)]
    public string Message { get; set; }

    [Column("ISInclude")]
    public bool Isinclude { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("TypeID")]
    public byte TypeId { get; set; }

    public int? CheckValue { get; set; }

    [StringLength(50)]
    public string AccountNo { get; set; }

    [StringLength(250)]
    public string AccountName { get; set; }

    [Column("AccountNoII")]
    [StringLength(50)]
    public string AccountNoIi { get; set; }

    [Column("AccountNameII")]
    [StringLength(250)]
    public string AccountNameIi { get; set; }
}
