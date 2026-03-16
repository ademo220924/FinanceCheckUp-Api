using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("McodeDesign")]
public partial class McodeDesign
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int? Code { get; set; }

    [StringLength(450)]
    public string MainDescription { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [StringLength(150)]
    public string TypeDescription { get; set; }

    public byte IsNegatif { get; set; }
}
