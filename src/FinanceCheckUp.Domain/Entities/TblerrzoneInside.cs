using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLErrzoneInside")]
public partial class TblerrzoneInside
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(25)]
    public string MainDescription { get; set; }

    [StringLength(1)]
    public string DebitCreditCode { get; set; }

    public byte ColorDesc { get; set; }

    [StringLength(750)]
    public string Description { get; set; }

    public byte ColorDescTax { get; set; }

    [StringLength(750)]
    public string DescriptionTax { get; set; }

    public byte ColorDescInside { get; set; }

    [StringLength(750)]
    public string DescriptionInside { get; set; }

    [StringLength(25)]
    public string InMainDesc { get; set; }

    [Column("InMainDescDC")]
    [StringLength(1)]
    public string InMainDescDc { get; set; }

    [StringLength(25)]
    public string OutMainDesc { get; set; }

    [Column("OutMainDescDC")]
    [StringLength(1)]
    public string OutMainDescDc { get; set; }

    public double? CheckAmount { get; set; }

    public byte? QueryType { get; set; }
}
