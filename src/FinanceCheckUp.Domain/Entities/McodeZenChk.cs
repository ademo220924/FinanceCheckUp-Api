using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("MCodeZenChk")]
public partial class McodeZenChk
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Code { get; set; }

    [StringLength(450)]
    public string MainDescription { get; set; }

    [Column("ShortTypeID")]
    [StringLength(2)]
    public string ShortTypeId { get; set; }
}
