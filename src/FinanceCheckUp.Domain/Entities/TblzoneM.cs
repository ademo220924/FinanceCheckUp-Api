using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLZoneM")]
public partial class TblzoneM
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("AccountMainID")]
    [StringLength(50)]
    public string AccountMainId { get; set; }

    [StringLength(350)]
    public string AccountMainDescription { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [Column("ISAlternative")]
    public int? Isalternative { get; set; }

    public int? IsNegative { get; set; }
}
