using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLKarZararByMonthMizan")]
public partial class TblkarZararByMonthMizan
{
    public double? Amount { get; set; }

    [Column("CompanyID")]
    public int? CompanyId { get; set; }

    public long Year { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
