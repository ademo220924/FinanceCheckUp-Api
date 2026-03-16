using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLErrzoneWordSub")]
public partial class TblerrzoneWordSub
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ColorID")]
    public int? ColorId { get; set; }

    [StringLength(250)]
    public string MainDescription { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    [StringLength(250)]
    public string SecredWord { get; set; }
}
