using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("NACECODEMain")]
public partial class Nacecodemain
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(755)]
    public string MainDescription { get; set; }

    [StringLength(25)]
    public string Code { get; set; }

    [StringLength(755)]
    public string Description { get; set; }

    [StringLength(25)]
    public string ManCode { get; set; }
}
