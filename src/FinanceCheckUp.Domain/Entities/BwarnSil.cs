using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("BWarnSil")]
public partial class BwarnSil
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(750)]
    public string Title { get; set; }

    [StringLength(750)]
    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
