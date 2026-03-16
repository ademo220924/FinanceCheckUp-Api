using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLErrzoneInsideWord")]
public partial class TblerrzoneInsideWord
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ErrorInsideID")]
    public int? ErrorInsideId { get; set; }

    [StringLength(750)]
    public string Description { get; set; }
}
