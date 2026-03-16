using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLF4FFALYTKRNETSTS")]
public partial class Tblf4ffalytkrnetst
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("YIL")]
    public int? Yil { get; set; }

    [Column("NACE")]
    public int? Nace { get; set; }

    [Column("SEKTOR")]
    [StringLength(355)]
    public string Sektor { get; set; }

    [Column("TUMYIL", TypeName = "decimal(18, 2)")]
    public decimal Tumyil { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Q1 { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Q2 { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Q3 { get; set; }

    [Column("FIRMASAYI", TypeName = "decimal(18, 2)")]
    public decimal? Firmasayi { get; set; }

    [Column("TUMYIL1", TypeName = "decimal(18, 2)")]
    public decimal Tumyil1 { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Q11 { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Q21 { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Q31 { get; set; }
}
