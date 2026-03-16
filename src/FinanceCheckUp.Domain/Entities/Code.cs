using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

public partial class Code
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string No { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    [Column("Code")]
    [StringLength(10)]
    public string Code1 { get; set; }

    [StringLength(25)]
    public string CodePass { get; set; }

    [StringLength(250)]
    public string CodeDuran { get; set; }

    [StringLength(5)]
    public string CodeDuranA { get; set; }

    [StringLength(55)]
    public string CodeDuranB { get; set; }

    [Column("WCapital")]
    [StringLength(5)]
    public string Wcapital { get; set; }

    public int? OrderNo { get; set; }

    [StringLength(250)]
    public string OtherDesc { get; set; }

    [StringLength(250)]
    public string OtherDesc1 { get; set; }

    public int? OrderNo1 { get; set; }

    public byte DashCheck { get; set; }

    public byte IsNegatif { get; set; }

    [Column("WCap")]
    public byte Wcap { get; set; }

    public byte KarZararCol { get; set; }
}
