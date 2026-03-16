using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBMLREPOR01MZN")]
public partial class Tbmlrepor01mzn
{
    public double? TumYil { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [StringLength(350)]
    public string GroupName { get; set; }

    public int? CounterZone { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    public byte IsFailed { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
