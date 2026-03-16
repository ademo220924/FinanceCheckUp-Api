using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("NACECODEMN")]
public partial class Nacecodemn
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(25)]
    public string Code { get; set; }

    [StringLength(255)]
    public string Description { get; set; }

    [StringLength(25)]
    public string ManCode { get; set; }
}
