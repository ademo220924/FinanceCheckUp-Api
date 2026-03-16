using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TTZDashBoardOranMzn")]
public partial class TtzdashBoardOranMzn
{
    [StringLength(250)]
    public string Description { get; set; }

    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int Year { get; set; }

    [Column("TypeID")]
    public int TypeId { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
