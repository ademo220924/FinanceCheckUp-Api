using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TTZDashBoardOzetLikiditeMzn")]
public partial class TtzdashBoardOzetLikiditeMzn
{
    [StringLength(250)]
    public string Description { get; set; }

    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int Year { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
