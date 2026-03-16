using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("SPO_ErrorList")]
public partial class SpoErrorList
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("XMLID")]
    public long? Xmlid { get; set; }

    [Column("SPNAME")]
    [StringLength(255)]
    public string Spname { get; set; }

    [StringLength(4000)]
    public string ErrorMessage { get; set; }

    public int? ErrorSeverity { get; set; }

    public int? ErrorState { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
