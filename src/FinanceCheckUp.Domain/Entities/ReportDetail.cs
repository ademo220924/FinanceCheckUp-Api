using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("ReportDetail")]
public partial class ReportDetail
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ReportID")]
    public int ReportId { get; set; }

    [Required]
    [StringLength(7)]
    public string ReportCode { get; set; }

    public byte IsNegeatif { get; set; }
}
