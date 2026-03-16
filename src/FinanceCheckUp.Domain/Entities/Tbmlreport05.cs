using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBMLREPORT05")]
public partial class Tbmlreport05
{
    public double? Q1 { get; set; }

    public double? Q2 { get; set; }

    public double? Q3 { get; set; }

    public double? TumYil { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [StringLength(350)]
    public string GroupName { get; set; }

    public int? CounterZone { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
