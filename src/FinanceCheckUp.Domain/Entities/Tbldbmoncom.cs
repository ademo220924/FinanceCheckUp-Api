using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLDBMONCOM")]
public partial class Tbldbmoncom
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public int? MainYear { get; set; }

    [Column("TRowCount")]
    public int? TrowCount { get; set; }

    [Column("TErrorRowCount")]
    public int? TerrorRowCount { get; set; }

    [Column("TNonErrorRowCount")]
    public int? TnonErrorRowCount { get; set; }

    [StringLength(150)]
    public string DocumentMonth { get; set; }

    [StringLength(150)]
    public string DocumentMonthTr { get; set; }

    public int? MainMonth { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }
}
