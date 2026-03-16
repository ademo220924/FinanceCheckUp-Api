using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLKarZararByMonth")]
public partial class TblkarZararByMonth
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public int? MainMonth { get; set; }

    public double? TotalGelir { get; set; }

    public int? MainYear { get; set; }

    public int? Year { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }
}
