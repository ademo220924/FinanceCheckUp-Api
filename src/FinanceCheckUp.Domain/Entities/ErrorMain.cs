using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("ErrorMain")]
public partial class ErrorMain
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(1551)]
    public string Error { get; set; }

    [StringLength(755)]
    public string Title { get; set; }
}
