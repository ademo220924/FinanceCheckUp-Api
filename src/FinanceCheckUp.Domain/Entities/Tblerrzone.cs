using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLErrzone")]
public partial class Tblerrzone : ISqlServerEntity<int>
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string MainDescription { get; set; }

    public byte? ColorDesc { get; set; }

    [StringLength(750)]
    public string Description { get; set; }

    public byte? ColorDescTax { get; set; }

    [StringLength(750)]
    public string DescriptionTax { get; set; }

    public byte? ColorDescInside { get; set; }

    [StringLength(750)]
    public string DescriptionInside { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
